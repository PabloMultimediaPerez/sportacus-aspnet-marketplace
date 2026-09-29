using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SPORTACUS_FRONT.Assemblers;
using SPORTACUS_FRONT.Models;
using SportacusGen.ApplicationCore.CEN.Sportacus;
using SportacusGen.ApplicationCore.EN.Sportacus;
using SportacusGen.Infraestructure.Repository.Sportacus;
using System.Collections.Generic;
using WebSportacus.Controllers;

namespace SPORTACUS_FRONT.Controllers
{
    public class AdminController : BasicController
    {
        private bool IsAdmin()
        {
            var email = HttpContext.Session.GetString("usuarioEmail");
            var esAdmin = HttpContext.Session.GetString("usuarioEsAdmin");

            return !string.IsNullOrEmpty(email) && esAdmin == "true";
        }

        private IActionResult ForbidOrLogin()
        {
            var email = HttpContext.Session.GetString("usuarioEmail");
            if (string.IsNullOrEmpty(email))
            {
                return RedirectToAction("Login", "Usuario");
            }

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Index()
        {
            if (!IsAdmin())
                return ForbidOrLogin();

            return View();
        }

        public IActionResult Usuarios()
        {
            if (!IsAdmin())
                return ForbidOrLogin();

            UsuarioRepository usuarioRepo = new UsuarioRepository();
            UsuarioCEN usuarioCEN = new UsuarioCEN(usuarioRepo);
            IList<UsuarioEN> usuariosEN = usuarioCEN.ReadAll(0, -1);
            IList<UsuarioViewModel> usuariosVM = UsuarioAssembler.ConvertListENToViewModel(usuariosEN);

            return View(usuariosVM);
        }

        public IActionResult Productos()
        {
            if (!IsAdmin())
                return ForbidOrLogin();

            ProductoRepository productoRepo = new ProductoRepository();
            ProductoCEN productoCEN = new ProductoCEN(productoRepo);
            IList<ProductoEN> productosEN = productoCEN.ReadAll(0, -1);
            IList<ProductoViewModel> productosVM = ProductoAssembler.ConvertListENToViewModel(productosEN);

            return View(productosVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EliminarUsuario(string email)
        {
            if (!IsAdmin())
                return ForbidOrLogin();

            if (!string.IsNullOrEmpty(email))
            {
                UsuarioRepository usuarioRepo = new UsuarioRepository();
                UsuarioCEN usuarioCEN = new UsuarioCEN(usuarioRepo);
                usuarioCEN.Destroy(email);
            }

            return RedirectToAction("Usuarios");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EliminarProducto(int id)
        {
            if (!IsAdmin())
                return ForbidOrLogin();

            ProductoRepository productoRepo = new ProductoRepository();
            ProductoCEN productoCEN = new ProductoCEN(productoRepo);
            productoCEN.Destroy(id);

            return RedirectToAction("Productos");
        }
    }
}
