using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using ShopEasyCRM.Models;

var builder = WebApplication.CreateBuilder(args);

// -------------------- SERVICIOS --------------------

// REGISTRO DEL CONTEXTO
builder.Services.AddDbContext<ShopEasyContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ShopEasyDB")));

// HABILITAR SESIONES
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // tiempo de inactividad antes de expirar
    options.Cookie.HttpOnly = true; // por seguridad, la cookie solo accesible por el servidor
    options.Cookie.IsEssential = true; // necesaria incluso si el usuario no da consentimiento de cookies
});

// AGREGAR AUTENTICACIÓN POR COOKIES
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Cuenta/Login";   // Página de login
        options.LogoutPath = "/Cuenta/Logout"; // Página de logout
    });

// AGREGAR FILTRO GLOBAL para evitar que el navegador guarde páginas en caché
builder.Services.AddControllersWithViews(options =>
{
    options.Filters.Add(new ResponseCacheAttribute
    {
        NoStore = true,
        Location = ResponseCacheLocation.None,
    });
});

var app = builder.Build();

// -------------------- PIPELINE HTTP --------------------
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// ACTIVAR SESIONES
app.UseSession();

// ACTIVAR AUTENTICACIÓN y AUTORIZACIÓN
app.UseAuthentication();
app.UseAuthorization();

// -------------------- ROUTING --------------------
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Cuenta}/{action=Login}/{id?}");

app.Run();
