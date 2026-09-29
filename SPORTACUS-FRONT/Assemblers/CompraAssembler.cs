using SPORTACUS_FRONT.Models;
using SportacusGen.ApplicationCore.EN.Sportacus;
using SportacusGen.ApplicationCore.Enumerated.Sportacus;
using System.Collections.Generic;
using System.Linq;

namespace SPORTACUS_FRONT.Assemblers
{
    public class CompraAssembler
    {
        public static CompraViewModel ConvertENToViewModel(CompraEN en)
        {
            if (en == null) return null;

            return new CompraViewModel
            {
                Id = en.Id,
                FechaInicio = en.FechaInicio.HasValue ? en.FechaInicio.Value : default(DateTime),
                PrecioFinal = en.PrecioFinal,
                MetodoPago = en.MetodoPago,
                EstadoCompra = en.EstadoCompra,
                ProductoId = en.Producto?.Id ?? 0,
                ProductoTitulo = en.Producto?.Titulo ?? "(Titulo producto no disponible)",
                NombreComprador = en.Comprador?.Nombre?? "(Nombre Comprador no disponible)",
                EmailComprador = en.Comprador?.Email ?? "(Email comprador no disponible)",
                NombreVendedor = en.Vendedor?.Nombre?? "(Nombre Vendedor no disponible)",
                EmailVendedor = en.Vendedor?.Email ?? "(Email vendedor no disponible)",
                DireccionEnvio = en.Comprador?.Direccion?? "(Direccion envio no asignada)"
            };
        }

        public static CompraEN ConvertViewModelToEN(CompraViewModel viewModel)
        {
            if (viewModel == null) return null;

            return new CompraEN
            {
                Id = viewModel.Id,
                FechaInicio = viewModel.FechaInicio,
                PrecioFinal = viewModel.PrecioFinal,
                EstadoCompra = (EstadoTransaccionEnum)viewModel.EstadoCompra,
                FechaVenta = viewModel.FechaCompra,
                Producto = new ProductoEN { Id = viewModel.ProductoId },
                Comprador = new UsuarioEN { Email = viewModel.EmailComprador },
                Vendedor = new UsuarioEN { Email = viewModel.EmailVendedor },
            };
        }

        // No devuelvas CompraEN aquí, sino un objeto con los datos básicos
        public static (DateTime? FechaInicio, double PrecioFinal, int ProductoId, string CompradorEmail, string VendedorEmail)
        ConvertViewModelToParams(CompraViewModel vm)
        {
            return (vm.FechaInicio, vm.PrecioFinal, vm.ProductoId, vm.EmailComprador, vm.EmailVendedor);
        }


        public static IList<CompraViewModel> ConvertListENToViewModel(IList<CompraEN> enList)
        {
            IList<CompraViewModel> vmList = new List<CompraViewModel>();

            foreach (CompraEN en in enList)
            {
                vmList.Add(ConvertENToViewModel(en));
            }

            return vmList;
        }
    }
}
