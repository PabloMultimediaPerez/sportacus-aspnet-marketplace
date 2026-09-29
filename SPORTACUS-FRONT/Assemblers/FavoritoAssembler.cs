using SportacusGen.ApplicationCore.EN.Sportacus;
using SportacusGen.ApplicationCore.Enumerated.Sportacus;
using SPORTACUS_FRONT.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SPORTACUS_FRONT.Assemblers
{
    public class FavoritoAssembler
    {
        public static FavoritoViewModel ConvertENToViewModel(FavoritoEN en)
        {
            if (en == null) return null;

            return new FavoritoViewModel
            {
                Id = en.Id,
                FechaMarcado = en.FechaMarcado,
                UsuarioEmail = en.Usuario?.Email ?? "(email usuario no disponible)",
                UsuarioNombre = en.Usuario?.Nombre ?? "(nombre usuario no disponible)", 
                ProductoId = en.Producto?.Id ?? 0,
                ProductoTitulo = en.Producto?.Titulo ?? "(título producto no disponible)",
                ProductoPrecio = en.Producto?.Precio??0.1,
                ProductoEstado = en.Producto?.Estado??EstadoProductoEnum.nuevo,
                ProductoCategoria = en.Producto?.Categoria??CategoriaEnum.ropa,
            };
        }

        // Mapea ViewModel -> EN, dejando las referencias mínimas para persistir
        public static FavoritoEN ConvertViewModelToEN(FavoritoViewModel viewModel)
        {
            if (viewModel == null) return null;

            if (viewModel.ProductoId <= 0)
                throw new ArgumentException("ProductoId inválido en FavoritoViewModel.");

            if (string.IsNullOrWhiteSpace(viewModel.UsuarioEmail))
                throw new ArgumentException("UsuarioEmail obligatorio en FavoritoViewModel.");

            return new FavoritoEN
            {
                Id = viewModel.Id,
                FechaMarcado = viewModel.FechaMarcado ?? DateTime.Now,
                Producto = new ProductoEN { Id = viewModel.ProductoId },
                Usuario = new UsuarioEN { Email = viewModel.UsuarioEmail }
            };
        }

        public static IList<FavoritoViewModel> ConvertListENToViewModel(IList<FavoritoEN> enList)
        {
            IList<FavoritoViewModel> vmList = new List<FavoritoViewModel>();

            foreach (FavoritoEN en in enList)
            {
                vmList.Add(ConvertENToViewModel(en));
            }

            return vmList;
        }

        // Utilidad opcional: convertir lista de ViewModel a EN
        public static IList<FavoritoEN> ConvertListViewModelToEN(IList<FavoritoViewModel> vmList)
        {
            if (vmList == null) return null;
            return vmList.Select(vm => ConvertViewModelToEN(vm)).ToList();
        }

    }
}
