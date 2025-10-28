using Microsoft.AspNetCore.Mvc;
using ShopEasyCRM.Models;
using System.Linq;

namespace ShopEasyCRM.Controllers
{

    using Microsoft.AspNetCore.Mvc;
    using System.Linq;

    public class CuentaController : Controller
    {
        private readonly ShopEasyContext _context;

        public CuentaController(ShopEasyContext context)
        {
            _context = context;
        }

        // GET y POST combinados
        [HttpGet, HttpPost]
        public IActionResult Login(string email = null, string password = null)
        {
            if (!string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(password))
            {
                // Buscar usuario
                var usuario = _context.Usuarios
                    .FirstOrDefault(u => u.Email == email && u.Password == password);

                if (usuario != null)
                {
                    // Usuario válido, redirige directo al Home
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
public IActionResult Logout()
{
    // 🔒 Limpia toda la sesión
    HttpContext.Session.Clear();

    // 🔒 Limpia cookies si las usas
    Response.Cookies.Delete(".AspNetCore.Cookies");

    // 🔁 Redirige al login
    return RedirectToAction("Login", "Cuenta");
}


    }
}