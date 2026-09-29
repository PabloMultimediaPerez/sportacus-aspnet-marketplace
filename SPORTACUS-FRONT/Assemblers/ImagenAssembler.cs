using SportacusGen.ApplicationCore.EN.Sportacus;
using SPORTACUS_FRONT.Models;
using System.Collections.Generic;
using System.Linq;

namespace SPORTACUS_FRONT.Assemblers
{
    public class ImagenAssembler
    {
        public static ImagenViewModel ConvertENToViewModel(ImagenEN en)
        {
            if (en == null) return null;

            return new ImagenViewModel
            {
                Id = en.Id,
                Url = en.Url,
                Descripcion = en.Descripcion,
                FechaSubida = en.FechaSubida,
                ProductoId = en.Producto?.Id ?? 0,
                ProductoNombre = en.Producto?.Titulo ?? "(titulo producto no disponible)"
            };
        }

        public static ImagenEN ConvertViewModelToEN(ImagenViewModel viewModel)
        {
            if (viewModel == null) return null;

            return new ImagenEN
            {
                Id = viewModel.Id,
                Url = viewModel.Url,
                Descripcion = viewModel.Descripcion,
                FechaSubida = viewModel.FechaSubida,
            };
        }

        public static IList<ImagenViewModel> ConvertListENToViewModel(IList<ImagenEN> enList)
        {
            IList<ImagenViewModel> vmList = new List<ImagenViewModel>();

            foreach (ImagenEN en in enList)
            {
                vmList.Add(ConvertENToViewModel(en));
            }

            return vmList;
        }
    }
}
