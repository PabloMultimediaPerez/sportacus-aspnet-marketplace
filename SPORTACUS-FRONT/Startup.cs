using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Http;
using System;

public class Startup
{
    public IConfiguration Configuration { get; }
    public Startup(IConfiguration configuration) => Configuration = configuration;

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddRazorPages();

        // Sesión para poder usar HttpContext.Session (usuarioEmail)
        services.AddSession(options =>
        {
            options.IdleTimeout = TimeSpan.FromMinutes(30);
            options.Cookie.HttpOnly = true;
            options.Cookie.IsEssential = true;
        });

        // Aquí podrías añadir otros servicios: EF, Identity, HttpClients, etc.
    }

    public void Configure(WebApplication app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseExceptionHandler("/Error");
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

        app.UseAuthentication();
        app.UseAuthorization();

        app.MapRazorPages();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Usuario}/{action=Login}/{id?}");
        });
    }
}