using SportacusGen.ApplicationCore.EN.Sportacus;
using SPORTACUS_FRONT.Models;
using System.Collections.Generic;
using System.Linq;
using SportacusGen.ApplicationCore.Enumerated.Sportacus;

namespace SPORTACUS_FRONT.Assemblers
{
    public class MensajeAssembler
    {
        public static MensajeViewModel ConvertENToViewModel(MensajeEN en)
        {
            if (en == null) return null;

            return new MensajeViewModel
            {
                Id = en.Id,
                Contenido = en.Contenido,
                FechaEnvio = en.FechaEnvio,
                TipoMensaje = en.TipoMensaje,
                UrlMultimedia = en.UrlMultimedia,
                ReceptorEmail = en.Receptor?.Email ?? "(Email receptor no disponible)",
                EmisorEmail = en.Emisor?.Email ?? "(Email emisor no disponible)",
                ReceptorNombre = en.Receptor?.Nombre ?? "(Nombre receptor no disponible)",
                EmisorNombre = en.Emisor?.Nombre ?? "(Nombre emisor no disponible)",    
            };
        }

        public static MensajeEN ConvertViewModelToEN(MensajeViewModel viewModel)
        {
            if (viewModel == null) return null;

            return new MensajeEN
            {
                Id = viewModel.Id,
                Contenido = viewModel.Contenido,
                FechaEnvio = viewModel.FechaEnvio,
                TipoMensaje = (SportacusGen.ApplicationCore.Enumerated.Sportacus.TipoMensajeEnum)viewModel.TipoMensaje,
                UrlMultimedia = viewModel.UrlMultimedia
            };
        }

        public static IList<MensajeViewModel> ConvertListENToViewModel(IList<MensajeEN> enList)
        {
            IList<MensajeViewModel> vmList = new List<MensajeViewModel>();

            foreach (MensajeEN en in enList)
            {
                vmList.Add(ConvertENToViewModel(en));
            }

            return vmList;
        }
    }
}
