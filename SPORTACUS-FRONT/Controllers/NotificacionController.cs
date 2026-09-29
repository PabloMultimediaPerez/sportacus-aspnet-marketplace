using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using SPORTACUS_FRONT.Assemblers;
using SPORTACUS_FRONT.Models;
using SportacusGen.ApplicationCore.CEN.Sportacus;
using SportacusGen.ApplicationCore.CP.Sportacus;
using SportacusGen.ApplicationCore.EN.Sportacus;
using SportacusGen.Infraestructure.CP;
using SportacusGen.Infraestructure.EN.Sportacus;
using SportacusGen.Infraestructure.Repository.Sportacus;
using System;
using System.Collections.Generic;
using WebSportacus.Controllers;

namespace SPORTACUS_FRONT.Controllers
{
    public class NotificacionController : BasicController
    {
        private readonly NotificacionCEN _notificacionCEN;
        public NotificacionController()
        {
            _notificacionCEN = new NotificacionCEN(new NotificacionRepository());
        }

        // GET: Notificacion
        // Muestra sólo las notificaciones del usuario actualmente logado
        public IActionResult Index()
        {
            try
            {
                var emailUsuario = HttpContext.Session.GetString("usuarioEmail");
                if (string.IsNullOrEmpty(emailUsuario))
                {
                    return RedirectToAction("Login", "Usuario");
                }

                SessionInitialize();

                NotificacionRepository notificacionRepo = new NotificacionRepository(session);
                NotificacionCEN notificacionCEN = new NotificacionCEN(notificacionRepo);

                // Sólo notificaciones cuyo Notificado.Email coincide con el usuario en sesión
                IList<NotificacionEN> listEN = notificacionCEN.ObtenerNotificacionesPorUsuario(emailUsuario);

                IEnumerable<NotificacionViewModel> listVM = NotificacionAssembler.ConvertListENToViewModel(listEN).ToList();

                SessionClose();

                return View(listVM);
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Error al cargar las notificaciones: " + ex.Message;
                return View(new List<NotificacionViewModel>());
            }
        }

        // GET: Notificacion/Details/5
        public IActionResult Details(int id)
        {
            SessionInitialize();

            NotificacionRepository notificacionRepo = new NotificacionRepository(session);
            NotificacionCEN notificacionCEN = new NotificacionCEN(notificacionRepo);

            NotificacionEN notificacionEN = notificacionCEN.ReadOID(id);
            NotificacionViewModel notificacionVM = NotificacionAssembler.ConvertENToViewModel(notificacionEN);

            SessionClose();

            return View(notificacionVM);
        }

        // GET: Notificacion/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Notificacion/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(NotificacionViewModel notificacionVM)
        {
            try
            {
                if (notificacionVM == null)
                    throw new ArgumentNullException(nameof(notificacionVM));

                NotificacionRepository notificacionRepo = new NotificacionRepository();
                NotificacionCEN notificacionCEN = new NotificacionCEN(notificacionRepo);
                notificacionCEN.New_(notificacionVM.Titulo, notificacionVM.Contenido, notificacionVM.FechaCreacion, 
                    notificacionVM.Leida, notificacionVM.TipoNotificacion, notificacionVM.UsuarioEmail);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Error al crear el mensaje: " + ex.Message;
                return View(notificacionVM);
            }
        }

        // GET: Notificacion/Edit/5
        public IActionResult Edit(int id)
        {
            SessionInitialize();

            NotificacionRepository notificacionRepo = new NotificacionRepository(session);
            NotificacionCEN notificacionCEN = new NotificacionCEN(notificacionRepo);

            NotificacionEN notificacionEN = notificacionCEN.ReadOID(id);
            NotificacionViewModel notificacionVM = NotificacionAssembler.ConvertENToViewModel(notificacionEN);

            SessionClose();

            return View(notificacionVM);
        }

        // POST: Notificacion/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, NotificacionViewModel notificacionVM)
        {
            try
            {
                if (notificacionVM == null)
                    return BadRequest();

                if (id != notificacionVM.Id)
                {
                    // Mostrar por qué falla en vez de devolver NotFound sin contexto
                    ModelState.AddModelError("", $"Id de ruta ({id}) no coincide con Id del modelo ({notificacionVM.Id}).");
                    return View(notificacionVM);
                }

                NotificacionRepository notificacionRepo = new NotificacionRepository();
                NotificacionCEN notificacionCEN = new NotificacionCEN(notificacionRepo);
                notificacionCEN.Modify(notificacionVM.Id, notificacionVM.Titulo, notificacionVM.Contenido, notificacionVM.FechaCreacion, notificacionVM.Leida, notificacionVM.TipoNotificacion);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Error al editar el favorito: " + ex.Message;
                return View(notificacionVM);
            }
        }

        // GET: Notificacion/Delete/5
        public IActionResult Delete(int id)
        {
            NotificacionRepository notificacionRepo = new NotificacionRepository();
            NotificacionCEN notificacionCEN = new NotificacionCEN(notificacionRepo);

            notificacionCEN.Destroy(id);

            return RedirectToAction(nameof(Index));
        }

        // POST: Notificacion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            try
            {
                _notificacionCEN.Destroy(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Error al eliminar la notificación: " + ex.Message;
                return RedirectToAction(nameof(Index));
            }
        }
    }
}
