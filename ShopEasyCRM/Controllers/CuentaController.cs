using Microsoft.AspNetCore.Mvc;
using ShopEasyCRM.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using System.Linq;

namespace ShopEasyCRM.Controllers
{
    public class CuentaController : Controller
    {
        private readonly ShopEasyContext _context;

        public CuentaController(ShopEasyContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(string email, string password)
        {
            if (!string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(password))
            {
                var usuario = _context.Usuarios
                    .FirstOrDefault(u => u.Email == email && u.Password == password);

                if (usuario != null)
                {
                    // Crear claims para el usuario
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, usuario.Email),
                        new Claim("UsuarioId", usuario.Id.ToString())
                    };

                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

                    // Iniciar sesión con cookie
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal);

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.Error = "Email o contraseña incorrecta";
                }
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            // Cerrar sesión de cookie
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            // Limpiar sesión si la estás usando
            HttpContext.Session.Clear();

            return RedirectToAction("Login", "Cuenta");
        }
    }
}
