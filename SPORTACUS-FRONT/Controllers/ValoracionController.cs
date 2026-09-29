using Microsoft.AspNetCore.Mvc;
using SPORTACUS_FRONT.Assemblers;
using SPORTACUS_FRONT.Models;
using SportacusGen.ApplicationCore.CEN.Sportacus;
using SportacusGen.ApplicationCore.CP.Sportacus;
using SportacusGen.ApplicationCore.EN.Sportacus;
using SportacusGen.ApplicationCore.IRepository.Sportacus;
using SportacusGen.Infraestructure.CP;
using SportacusGen.Infraestructure.EN.Sportacus;
using SportacusGen.Infraestructure.Repository.Sportacus;
using System;
using System.Collections.Generic;
using WebSportacus.Controllers;

namespace SPORTACUS_FRONT.Controllers
{
    public class ValoracionController : BasicController
    {

        public ValoracionController()
        {
        }

        // GET: Valoracion
        public IActionResult Index()
        {
            try
            {
                SessionInitialize();

                ValoracionRepository valoracionRepo = new ValoracionRepository(session);
                ValoracionCEN valoracionCEN = new ValoracionCEN(valoracionRepo);

                IList<ValoracionEN> listEN = valoracionCEN.ReadAll(0, -1);

                IEnumerable<ValoracionViewModel> listVM = ValoracionAssembler.ConvertListENToViewModel(listEN).ToList();

                SessionClose();

                return View(listVM);
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Error al cargar las valoraciones: " + ex.Message;
                return View(new List<ValoracionViewModel>());
            }
        }

        // GET: Valoracion/Details/5
        public IActionResult Details(int id)
        {
            SessionInitialize();

            ValoracionRepository valoracionRepo = new ValoracionRepository(session);
            ValoracionCEN valoracionCEN = new ValoracionCEN(valoracionRepo);

            ValoracionEN valoracionEN = valoracionCEN.ReadOID(id);
            ValoracionViewModel valoracionVM = ValoracionAssembler.ConvertENToViewModel(valoracionEN);

            SessionClose();

            return View(valoracionVM);
        }

        // GET: Valoracion/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Valoracion/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ValoracionViewModel valoracionVM)
        {
            try
            {

                if (valoracionVM == null)
                    throw new ArgumentNullException(nameof(valoracionVM));

                ValoracionRepository valoracionRepo = new ValoracionRepository();
                ValoracionCEN valoracionCEN = new ValoracionCEN(valoracionRepo);
                valoracionCEN.New_(valoracionVM.Puntuacion, valoracionVM.Comentario, valoracionVM.FechaValoracion, 
                    valoracionVM.EmailVendedor, valoracionVM.EmailComprador, valoracionVM.ProductoId);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Error al crear la valoración: " + ex.Message;
                return View(valoracionVM);
            }
        }

        // GET: Valoracion/Edit/5
        public IActionResult Edit(int id)
        {
            SessionInitialize();

            ValoracionRepository valoracionRepo = new ValoracionRepository(session);
            ValoracionCEN valoracionCEN = new ValoracionCEN(valoracionRepo);

            ValoracionEN valoracionEN = valoracionCEN.ReadOID(id);
            ValoracionViewModel valoracionVM = ValoracionAssembler.ConvertENToViewModel(valoracionEN);

            SessionClose();

            return View(valoracionVM);
        }

        // POST: Valoracion/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, ValoracionViewModel valoracionVM)
        {
            try
            {
                if (valoracionVM == null)
                    return BadRequest();

                if (id != valoracionVM.Id)
                {
                    // Mostrar por qué falla en vez de devolver NotFound sin contexto
                    ModelState.AddModelError("", $"Id de ruta ({id}) no coincide con Id del modelo ({valoracionVM.Id}).");
                    return View(valoracionVM);
                }

                ValoracionRepository valoracionRepo = new ValoracionRepository();
                ValoracionCEN valoracionCEN = new ValoracionCEN(valoracionRepo);
                valoracionCEN.Modify(valoracionVM.Id, valoracionVM.Puntuacion, valoracionVM.Comentario, valoracionVM.FechaValoracion);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Error al editar el favorito: " + ex.Message;
                return View(valoracionVM);
            }
        }

        // GET: Valoracion/Delete/5
        public IActionResult Delete(int id)
        {
            ValoracionRepository valoracionRepo = new ValoracionRepository();
            ValoracionCEN valoracionCEN = new ValoracionCEN(valoracionRepo);

            valoracionCEN.Destroy(id);

            return RedirectToAction(nameof(Index));
        }

        // POST: Valoracion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            try
            {
                ValoracionRepository valoracionRepository = new ValoracionRepository();
                ValoracionCEN _valoracionCEN = new ValoracionCEN(valoracionRepository);

                _valoracionCEN.Destroy(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Error al eliminar la valoración: " + ex.Message;
                return RedirectToAction(nameof(Index));
            }
        }
    }
}
