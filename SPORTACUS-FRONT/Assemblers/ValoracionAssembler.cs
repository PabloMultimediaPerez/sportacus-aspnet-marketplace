using SportacusGen.ApplicationCore.EN.Sportacus;
using SPORTACUS_FRONT.Models;
using System.Collections.Generic;
using System.Linq;

namespace SPORTACUS_FRONT.Assemblers
{
    public class ValoracionAssembler
    {
        public static ValoracionViewModel ConvertENToViewModel(ValoracionEN en)
        {
            if (en == null) return null;

            return new ValoracionViewModel
            {
                Id = en.Id,
                Puntuacion = en.Puntuacion,
                Comentario = en.Comentario,
                FechaValoracion = en.FechaValoracion,
                ProductoId = en.Producto?.Id ?? 0,
                ProductoNombre = en.Producto?.Titulo ?? "(Título producto no disponible)",
                EmailComprador = en.Comprador?.Email ?? "(Email comprador no disponible)",
                EmailVendedor = en.Vendedor?.Email ?? "(Email vendedor no disponible)",
                NombreComprador = en.Comprador.Nombre ?? "(Nombre comprador no disponible)",
                NombreVendedor = en.Vendedor.Nombre ?? "(Nombre vendedor no disponible)"
            };
        }

        public static ValoracionEN ConvertViewModelToEN(ValoracionViewModel viewModel)
        {
            if (viewModel == null) return null;

            return new ValoracionEN
            {
                Id = viewModel.Id,
                Puntuacion = viewModel.Puntuacion,
                Comentario = viewModel.Comentario,
                FechaValoracion = viewModel.FechaValoracion
            };
        }

        public static IList<ValoracionViewModel> ConvertListENToViewModel(IList<ValoracionEN> enList)
        {
            IList<ValoracionViewModel> vmList = new List<ValoracionViewModel>();

            foreach (ValoracionEN en in enList)
            {
                vmList.Add(ConvertENToViewModel(en));
            }

            return vmList;
        }
    }
}
