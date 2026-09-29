using Microsoft.AspNetCore.Mvc;
using SPORTACUS_FRONT.Assemblers;
using SPORTACUS_FRONT.Models;
using SportacusGen.ApplicationCore.CEN.Sportacus;
using SportacusGen.ApplicationCore.CP.Sportacus;
using SportacusGen.ApplicationCore.EN.Sportacus;
using SportacusGen.Infraestructure.CP;
using SportacusGen.Infraestructure.EN.Sportacus;
using SportacusGen.Infraestructure.Repository;
using SportacusGen.Infraestructure.Repository.Sportacus;
using System;
using System.Collections.Generic;
using WebSportacus.Controllers;

namespace SPORTACUS_FRONT.Controllers
{
    public class FavoritoController : BasicController
    {
        private readonly FavoritoCEN _favoritoCEN;

        public FavoritoController()
        {
            // Crear una instancia concreta de IFavoritoRepository
            var favoritoRepository = new FavoritoRepository();
            _favoritoCEN = new FavoritoCEN(favoritoRepository);
        }

        // GET: Favorito
        public IActionResult Index()
        {
            try
            {
                SessionInitialize();

                FavoritoRepository favoritoRepo = new FavoritoRepository(session);
                FavoritoCEN favoritoCEN = new FavoritoCEN(favoritoRepo);

                IList<FavoritoEN> listEN = favoritoCEN.ReadAll(0, -1);

                IEnumerable<FavoritoViewModel> listVM = FavoritoAssembler.ConvertListENToViewModel(listEN).ToList();

                SessionClose();

                return View(listVM);
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Error al cargar las compras: " + ex.Message;
                return View(new List<FavoritoViewModel>());
            }
        }

        // GET: Favorito/Details/5
        public IActionResult Details(int id)
        {
            SessionInitialize();

            FavoritoRepository favoritoRepo = new FavoritoRepository(session);
            FavoritoCEN favoritoCEN = new FavoritoCEN(favoritoRepo);

            FavoritoEN favoritoEN = favoritoCEN.ReadOID(id);
            FavoritoViewModel favoritoVM = FavoritoAssembler.ConvertENToViewModel(favoritoEN);

            SessionClose();

            return View(favoritoVM);
        }

        // GET: Favorito/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Favorito/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(FavoritoViewModel favoritoVM)
        {
            try
            {
                if (favoritoVM == null)
                    throw new ArgumentNullException(nameof(favoritoVM));

                FavoritoRepository favoritoRepo = new FavoritoRepository();
                FavoritoCEN favoritoCEN = new FavoritoCEN(favoritoRepo);
                favoritoCEN.New_(favoritoVM.FechaMarcado, favoritoVM.ProductoId, favoritoVM.UsuarioEmail);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Error al crear el favorito: " + ex.Message;
                return View(favoritoVM);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult MarcarFavorito(FavoritoViewModel favoritoVM)
        {

            var favoritoEN = new FavoritoEN
            {
                Usuario = new UsuarioEN { Email = favoritoVM.UsuarioEmail },
                Producto = new ProductoEN { Id = favoritoVM.ProductoId },
                FechaMarcado = DateTime.Now
            };

            new FavoritoCEN(new FavoritoRepository()).New_(favoritoEN.FechaMarcado, favoritoEN.Producto.Id, favoritoEN.Usuario.Email);

            return RedirectToAction("Index", "Producto");
        }

        // GET: Favorito/Edit/5
        public IActionResult Edit(int id)
        {
            SessionInitialize();

            FavoritoRepository favoritoRepo = new FavoritoRepository(session);
            FavoritoCEN favoritoCEN = new FavoritoCEN(favoritoRepo);

            FavoritoEN favoritoEN = favoritoCEN.ReadOID(id);
            FavoritoViewModel favoritoVM = FavoritoAssembler.ConvertENToViewModel(favoritoEN);

            SessionClose();

            return View(favoritoVM);
        }

        // POST: Favorito/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, FavoritoViewModel favoritoVM)
        {
            try
            {
                if (favoritoVM == null)
                    return BadRequest();

                if (id != favoritoVM.Id)
                {
                    // Mostrar por qué falla en vez de devolver NotFound sin contexto
                    ModelState.AddModelError("", $"Id de ruta ({id}) no coincide con Id del modelo ({favoritoVM.Id}).");
                    return View(favoritoVM);
                }

                FavoritoRepository favoritoRepo = new FavoritoRepository();
                FavoritoCEN favoritoCEN = new FavoritoCEN(favoritoRepo);
                favoritoCEN.Modify(favoritoVM.Id, favoritoVM.FechaMarcado);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Error al editar el favorito: " + ex.Message;
                return View(favoritoVM);
            }
        }

        // GET: Favorito/Delete/5
        public IActionResult Delete(int id)
        {
            FavoritoRepository favoritoRepo = new FavoritoRepository();
            FavoritoCEN favoritoCEN = new FavoritoCEN(favoritoRepo);
            favoritoCEN.Destroy(id);

            return RedirectToAction(nameof(Index));
        }

        // POST: Favorito/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            try
            {
                _favoritoCEN.Destroy(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Error al eliminar el favorito: " + ex.Message;
                return RedirectToAction(nameof(Index));
            }
        }
    }
}
