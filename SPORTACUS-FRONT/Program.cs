using Microsoft.AspNetCore.Http;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Sesión para poder usar HttpContext.Session (usuarioEmail)
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// Habilitamos la sesión antes de auth y endpoints
app.UseSession();

// Middleware para redirigir a Login si no hay usuario en sesión en rutas protegidas
app.Use(async (context, next) =>
{
    var path = context.Request.Path.Value?.ToLower() ?? string.Empty;

    bool isAuthPage =
        path.StartsWith("/usuario/login") ||
        path.StartsWith("/usuario/create");

    bool requiresAuth =
        (path.StartsWith("/usuario") && !isAuthPage) ||
        path.StartsWith("/mensaje") ||
        path.StartsWith("/producto/create") ||
        path.StartsWith("/compra") ||
        path.StartsWith("/favorito") ||
        path.StartsWith("/notificacion") ||
        path.StartsWith("/valoracion");

    if (requiresAuth)
    {
        var email = context.Session.GetString("usuarioEmail");
        if (string.IsNullOrEmpty(email))
        {
            context.Response.Redirect("/Usuario/Login");
            return;
        }
    }

    await next();
});

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Usuario}/{action=Login}/{id?}");

app.Run();
