using SportacusGen.ApplicationCore.EN.Sportacus;
using SPORTACUS_FRONT.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SPORTACUS_FRONT.Assemblers
{
    public class NotificacionAssembler
    {
        public static NotificacionViewModel ConvertENToViewModel(NotificacionEN en)
        {
            if (en == null) return null;

            var vm = new NotificacionViewModel
            {
                Id = en.Id,
                Titulo = en.Titulo,
                Contenido = en.Contenido,
                FechaCreacion = en.FechaCreacion,
                Leida = en.Leida,
                TipoNotificacion = en.TipoNotificacion,
                UsuarioEmail = en.Notificado?.Email ?? "(Email de usuario no disponible)",
                UsuarioNombre = en.Notificado?.Nombre ?? "(Nombre de usuario no disponible)"
            };

            // Si la notificación está asociada a un mensaje, rellenamos datos para navegar al chat
            if (en.Mensaje != null)
            {
                vm.MensajeId = en.Mensaje.Id;

                try
                {
                    var notificadoEmail = en.Notificado?.Email;
                    var emisorEmail = en.Mensaje.Emisor?.Email;
                    var receptorEmail = en.Mensaje.Receptor?.Email;

                    if (!string.IsNullOrEmpty(notificadoEmail))
                    {
                        if (!string.IsNullOrEmpty(emisorEmail) &&
                            string.Equals(notificadoEmail, emisorEmail, StringComparison.OrdinalIgnoreCase))
                        {
                            vm.OtroUsuarioEmail = receptorEmail;
                        }
                        else if (!string.IsNullOrEmpty(receptorEmail) &&
                                 string.Equals(notificadoEmail, receptorEmail, StringComparison.OrdinalIgnoreCase))
                        {
                            vm.OtroUsuarioEmail = emisorEmail;
                        }
                    }
                }
                catch
                {
                    // Si algo falla al calcular el otro usuario, dejamos el email vacío
                }
            }

            return vm;
        }

        public static NotificacionEN ConvertViewModelToEN(NotificacionViewModel viewModel)
        {
            if (viewModel == null) return null;

            return new NotificacionEN
            {
                Id = viewModel.Id,
                Titulo = viewModel.Titulo,
                Contenido = viewModel.Contenido,
                FechaCreacion = viewModel.FechaCreacion,
                Leida = viewModel.Leida,
                TipoNotificacion = (SportacusGen.ApplicationCore.Enumerated.Sportacus.TipoNotificacionEnum)viewModel.TipoNotificacion
            };
        }

        public static IList<NotificacionViewModel> ConvertListENToViewModel(IList<NotificacionEN> enList)
        {
            IList<NotificacionViewModel> vmList = new List<NotificacionViewModel>();

            foreach (NotificacionEN en in enList)
            {
                vmList.Add(ConvertENToViewModel(en));
            }

            return vmList;
        }
    }
}

