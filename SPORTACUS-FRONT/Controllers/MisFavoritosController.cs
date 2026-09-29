using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SPORTACUS_FRONT.Assemblers;
using SPORTACUS_FRONT.Models;
using SportacusGen.ApplicationCore.CEN.Sportacus;
using SportacusGen.ApplicationCore.EN.Sportacus;
using SportacusGen.Infraestructure.Repository.Sportacus;
using System;
using System.Collections.Generic;
using System.Linq;
using WebSportacus.Controllers;

namespace SPORTACUS_FRONT.Controllers
{
    public class MisFavoritosController : BasicController
    {
        // GET: MisFavoritos
        // Muestra solo los favoritos del usuario actualmente logado
        public IActionResult Index()
        {
            var emailUsuario = HttpContext.Session.GetString("usuarioEmail");
            if (string.IsNullOrEmpty(emailUsuario))
            {
                return RedirectToAction("Login", "Usuario");
            }

            try
            {
                SessionInitialize();

                var favoritoRepo = new FavoritoRepository(session);
                var favoritoCEN = new FavoritoCEN(favoritoRepo);

                IList<FavoritoEN> listEN = favoritoCEN.ObtenerFavoritosPorUsuario(emailUsuario);
                var listVM = FavoritoAssembler.ConvertListENToViewModel(listEN).ToList();

                SessionClose();

                // Reutilizamos la vista existente de Favorito/Index
                return View("~/Views/Favorito/Index.cshtml", listVM);
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Error al cargar los favoritos: " + ex.Message;
                return View("~/Views/Favorito/Index.cshtml", new List<FavoritoViewModel>());
            }
        }

        // POST: MisFavoritos/Add
        // Añade un producto a favoritos para el usuario logado desde el detalle de producto
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(int productoId)
        {
            var emailUsuario = HttpContext.Session.GetString("usuarioEmail");
            if (string.IsNullOrEmpty(emailUsuario))
            {
                return RedirectToAction("Login", "Usuario");
            }

            try
            {
                var favoritoRepo = new FavoritoRepository();
                var favoritoCEN = new FavoritoCEN(favoritoRepo);

                // Evitamos duplicados para este usuario y producto
                var existentes = favoritoCEN.ObtenerFavoritosPorProducto(productoId);
                bool yaExiste = existentes.Any(f => f.Usuario != null &&
                    string.Equals(f.Usuario.Email, emailUsuario, StringComparison.OrdinalIgnoreCase));

                if (!yaExiste)
                {
                    favoritoCEN.New_(DateTime.Now, productoId, emailUsuario);
                    TempData["FavoritoOk"] = "Producto añadido a favoritos";
                }
                else
                {
                    TempData["FavoritoOk"] = "Este producto ya está en tus favoritos";
                }
            }
            catch
            {
                TempData["FavoritoOk"] = "No se ha podido añadir a favoritos";
            }

            return RedirectToAction("Details", "Producto", new { id = productoId });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Remove(int productoId)
        {
            var emailUsuario =
                HttpContext.Session.GetString("usuarioEmail");

            if (string.IsNullOrEmpty(emailUsuario))
            {
                return RedirectToAction("Login", "Usuario");
            }

            try
            {
                var favoritoRepo =
                    new FavoritoRepository();

                var favoritoCEN =
                    new FavoritoCEN(favoritoRepo);

                // Buscamos los favoritos asociados al producto
                var existentes =
                    favoritoCEN.ObtenerFavoritosPorProducto(productoId);

                // Buscamos específicamente el favorito
                // perteneciente al usuario que está logado
                var favoritoExistente =
                    existentes?
                        .FirstOrDefault(f =>
                            f.Usuario != null &&
                            string.Equals(
                                f.Usuario.Email,
                                emailUsuario,
                                StringComparison.OrdinalIgnoreCase
                            ));

                if (favoritoExistente != null)
                {
                    // Eliminamos usando el ID DEL FAVORITO,
                    // no el ID del producto
                    favoritoCEN.Destroy(favoritoExistente.Id);

                    TempData["FavoritoOk"] =
                        "Producto eliminado de favoritos";
                }
                else
                {
                    TempData["FavoritoOk"] =
                        "El producto no estaba en tus favoritos";
                }
            }
            catch (Exception ex)
            {
                TempData["FavoritoOk"] =
                    "No se ha podido eliminar de favoritos: "
                    + ex.Message;
            }

            return RedirectToAction(
                "Details",
                "Producto",
                new { id = productoId }
            );
        }
    }
}
