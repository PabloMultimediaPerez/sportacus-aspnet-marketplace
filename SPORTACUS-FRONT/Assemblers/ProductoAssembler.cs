using SportacusGen.ApplicationCore.EN.Sportacus;
using SPORTACUS_FRONT.Models;
using System.Collections.Generic;
using System.Linq;

namespace SPORTACUS_FRONT.Assemblers
{
    public class ProductoAssembler
    {
        public static ProductoViewModel ConvertENToViewModel(ProductoEN en)
        {
            if (en == null) return null;

            return new ProductoViewModel
            {
                Id = en.Id,
                Titulo = en.Titulo,
                UsuarioEmail = en.Vende?.Email ?? "(Email de usuario no disponible)",
                UsuarioNombre = en.Vende?.Nombre ?? "(Nombre de usuario no disponible)",
                Descripcion = en.Descripcion,
                Precio = en.Precio,
                Estado = en.Estado,
                Categoria = en.Categoria,
                FechaPublicacion = en.FechaPublicacion,
                Disponible = en.Disponible,
                ImagenUrlPrincipal = en.Imagen != null && en.Imagen.Any()
                    ? en.Imagen.First().Url
                    : null,
                ImagenesUrls = en.Imagen != null
                    ? en.Imagen.Select(i => i.Url).ToList()
                    : new List<string>(),
            };
        }

        public static ProductoEN ConvertViewModelToEN(ProductoViewModel viewModel)
        {
            if (viewModel == null) return null;

            return new ProductoEN
            {
                Id = viewModel.Id,
                Titulo = viewModel.Titulo,
                Descripcion = viewModel.Descripcion,
                Precio = viewModel.Precio,
                Estado = viewModel.Estado,
                Categoria = viewModel.Categoria,
                FechaPublicacion = viewModel.FechaPublicacion,
                Disponible = viewModel.Disponible
            };
        }

        public static IList<ProductoViewModel> ConvertListENToViewModel(IList<ProductoEN> enList)
        {
            IList<ProductoViewModel> vmList = new List<ProductoViewModel>();

            foreach (ProductoEN en in enList)
            {
                vmList.Add(ConvertENToViewModel(en));
            }

            return vmList;
        }
    }
}
