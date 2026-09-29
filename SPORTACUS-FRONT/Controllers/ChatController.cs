using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SPORTACUS_FRONT.Assemblers;
using SPORTACUS_FRONT.Models;
using SportacusGen.ApplicationCore.CEN.Sportacus;
using SportacusGen.ApplicationCore.CP.Sportacus;
using SportacusGen.ApplicationCore.EN.Sportacus;
using SportacusGen.ApplicationCore.IRepository.Sportacus;
using SportacusGen.ApplicationCore.Enumerated.Sportacus;
using SportacusGen.Infraestructure.CP;
using SportacusGen.Infraestructure.Repository.Sportacus;
using System;
using System.Collections.Generic;
using System.Linq;
using WebSportacus.Controllers;

namespace SPORTACUS_FRONT.Controllers
{
    public class ChatController : BasicController
    {
        // GET: Chat
        public IActionResult Index()
        {
            try
            {
                var emailActual = HttpContext.Session.GetString("usuarioEmail");
                if (string.IsNullOrEmpty(emailActual))
                {
                    return RedirectToAction("Login", "Usuario");
                }

                SessionInitialize();

                MensajeRepository mensajeRepo = new MensajeRepository(session);
                MensajeCEN mensajeCEN = new MensajeCEN(mensajeRepo);
                IList<MensajeEN> listEN = mensajeCEN.ObtenerConversacionesPorUsuario(emailActual);

                var listVM = MensajeAssembler.ConvertListENToViewModel(listEN).ToList();

                SessionClose();

                ViewBag.UsuarioActualEmail = emailActual;

                return View(listVM);
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Error al cargar los chats: " + ex.Message;
                return View(new List<MensajeViewModel>());
            }
        }

        // GET: Chat/Conversation?otroEmail=...
        public IActionResult Conversation(string otroEmail)
        {
            var emailActual = HttpContext.Session.GetString("usuarioEmail");
            if (string.IsNullOrEmpty(emailActual))
            {
                return RedirectToAction("Login", "Usuario");
            }

            if (string.IsNullOrEmpty(otroEmail))
            {
                return RedirectToAction(nameof(Index));
            }

            SessionInitialize();

            MensajeRepository mensajeRepo = new MensajeRepository(session);
            MensajeCEN mensajeCEN = new MensajeCEN(mensajeRepo);
            IList<MensajeEN> mensajesEN = mensajeCEN.ObtenerMensajesEntreUsuarios(emailActual, otroEmail);

            var mensajesVM = MensajeAssembler.ConvertListENToViewModel(mensajesEN).ToList();

            SessionClose();

            string otroNombre = otroEmail;
            if (mensajesVM.Any())
            {
                var first = mensajesVM[0];
                if (string.Equals(first.EmisorEmail, emailActual, StringComparison.OrdinalIgnoreCase))
                {
                    otroNombre = first.ReceptorNombre;
                }
                else
                {
                    otroNombre = first.EmisorNombre;
                }
            }

            ViewBag.OtroEmail = otroEmail;
            ViewBag.OtroNombre = otroNombre;
            ViewBag.UsuarioActualEmail = emailActual;

            return View(mensajesVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Send(string otroEmail, string contenido)
        {
            var emailActual = HttpContext.Session.GetString("usuarioEmail");
            if (string.IsNullOrEmpty(emailActual))
            {
                return RedirectToAction("Login", "Usuario");
            }

            if (string.IsNullOrWhiteSpace(otroEmail) || string.IsNullOrWhiteSpace(contenido))
            {
                return RedirectToAction("Conversation", new { otroEmail });
            }

            try
            {
                // 1) Crear el mensaje de chat
                MensajeRepository mensajeRepo = new MensajeRepository();
                MensajeCEN mensajeCEN = new MensajeCEN(mensajeRepo);
                int mensajeId = mensajeCEN.New_(
                    contenido,
                    DateTime.Now,
                    SportacusGen.ApplicationCore.Enumerated.Sportacus.TipoMensajeEnum.texto,
                    string.Empty, // UrlMultimedia no puede ser null en la BD
                    emailActual,
                    otroEmail,
                    false
                );

                // 2) Crear una notificación para el receptor avisando del nuevo mensaje
                NotificacionRepository notificacionRepo = new NotificacionRepository();
                NotificacionCEN notificacionCEN = new NotificacionCEN(notificacionRepo);

                string titulo = "Nuevo mensaje";
                string resumen = contenido;
                if (!string.IsNullOrEmpty(contenido) && contenido.Length > 80)
                {
                    resumen = contenido.Substring(0, 80) + "...";
                }

                notificacionCEN.New_(
                    titulo,
                    resumen,
                    DateTime.Now,
                    false,
                    TipoNotificacionEnum.mensaje,
                    otroEmail
                );
            }
            catch
            {
                // Si algo falla al enviar, volvemos igualmente a la conversación
            }

            return RedirectToAction("Conversation", new { otroEmail });
        }
    }
}
