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
    public class MensajeController : BasicController
    {
        private readonly MensajeCEN _mensajeCEN;
        public MensajeController()
        {
            _mensajeCEN = new MensajeCEN(new MensajeRepository());
        }

        // GET: Mensaje
        public IActionResult Index()
        {
            try
            {
                SessionInitialize();

                MensajeRepository mensajeRepo = new MensajeRepository(session);
                MensajeCEN mensajeCEN = new MensajeCEN(mensajeRepo);

                IList<MensajeEN> listEN = mensajeCEN.ReadAll(0, -1);

                IEnumerable<MensajeViewModel> listVM = MensajeAssembler.ConvertListENToViewModel(listEN).ToList();

                SessionClose();

                return View(listVM);
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Error al cargar los mensajes: " + ex.Message;
                return View(new List<MensajeViewModel>());
            }
        }

        // GET: Mensaje/Details/5
        public IActionResult Details(int id)
        {
            SessionInitialize();

            MensajeRepository mensajeRepo = new MensajeRepository(session);
            MensajeCEN mensajeCEN = new MensajeCEN(mensajeRepo);

            MensajeEN mensajeEN = mensajeCEN.ReadOID(id);
            MensajeViewModel mensajeVM = MensajeAssembler.ConvertENToViewModel(mensajeEN);

            SessionClose();

            return View(mensajeVM);
        }

        // GET: Mensaje/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Mensaje/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(MensajeViewModel mensajeVM)
        {
            try
            {
                if (mensajeVM == null)
                    throw new ArgumentNullException(nameof(mensajeVM));

                MensajeRepository mensajeRepo = new MensajeRepository();
                MensajeCEN mensajeCEN = new MensajeCEN(mensajeRepo);
                mensajeCEN.New_(mensajeVM.Contenido, mensajeVM.FechaEnvio, mensajeVM.TipoMensaje, 
                    mensajeVM.UrlMultimedia, mensajeVM.EmisorEmail, mensajeVM.ReceptorEmail, mensajeVM.Leido);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Error al crear el mensaje: " + ex.Message;
                return View(mensajeVM);
            }
        }

        // GET: Mensaje/Edit/5
        public IActionResult Edit(int id)
        {
            SessionInitialize();

            MensajeRepository mensajeRepo = new MensajeRepository(session);
            MensajeCEN mensajeCEN = new MensajeCEN(mensajeRepo);

            MensajeEN mensajeEN = mensajeCEN.ReadOID(id);
            MensajeViewModel mensajeVM = MensajeAssembler.ConvertENToViewModel(mensajeEN);

            SessionClose();

            return View(mensajeVM);
        }

        // POST: Mensaje/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, MensajeViewModel mensajeVM)
        {
            try
            {
                if (mensajeVM == null)
                    return BadRequest();

                if (id != mensajeVM.Id)
                {
                    // Mostrar por qué falla en vez de devolver NotFound sin contexto
                    ModelState.AddModelError("", $"Id de ruta ({id}) no coincide con Id del modelo ({mensajeVM.Id}).");
                    return View(mensajeVM);
                }

                MensajeRepository mensajeRepo = new MensajeRepository();
                MensajeCEN mensajeCEN = new MensajeCEN(mensajeRepo);
                mensajeCEN.Modify(mensajeVM.Id, mensajeVM.Contenido, mensajeVM.FechaEnvio, mensajeVM.TipoMensaje, mensajeVM.UrlMultimedia, mensajeVM.Leido);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Error al editar el favorito: " + ex.Message;
                return View(mensajeVM);
            }
        }

        // GET: Mensaje/Delete/5
        public IActionResult Delete(int id)
        {
            MensajeRepository mensajeRepo = new MensajeRepository();
            MensajeCEN mensajeCEN = new MensajeCEN(mensajeRepo);

            mensajeCEN.Destroy(id);

            return RedirectToAction(nameof(Index));
        }

        // POST: Mensaje/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            try
            {
                _mensajeCEN.Destroy(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Error al eliminar el mensaje: " + ex.Message;
                return RedirectToAction(nameof(Index));
            }
        }
    }
}
