using SportacusGen.ApplicationCore.EN.Sportacus;
using SPORTACUS_FRONT.Models;
using System.Collections.Generic;
using System.Linq;

namespace SPORTACUS_FRONT.Assemblers
{
    public class UsuarioAssembler
    {
        public static UsuarioViewModel ConvertENToViewModel(UsuarioEN en)
        {
            if (en == null) return null;

            return new UsuarioViewModel
            {
                Email = en.Email,
                Nombre = en.Nombre,
                Telefono = en.Telefono,
                Direccion = en.Direccion,
                FechaRegistro = en.FechaRegistro,
                EsAdministrador = en.EsAdministrador,
                Pass = en.Pass
            };
        }

        public static UsuarioEN ConvertViewModelToEN(UsuarioViewModel viewModel)
        {
            if (viewModel == null) return null;

            return new UsuarioEN
            {
                Email = viewModel.Email,
                Nombre = viewModel.Nombre,
                Telefono = viewModel.Telefono,
                Direccion = viewModel.Direccion,
                FechaRegistro = viewModel.FechaRegistro,
                EsAdministrador = viewModel.EsAdministrador,
                Pass = viewModel.Pass
            };
        }

        public static IList<UsuarioViewModel> ConvertListENToViewModel(IList<UsuarioEN> enList)
        {
            IList<UsuarioViewModel> vmList = new List<UsuarioViewModel>();

            foreach (UsuarioEN en in enList)
            {
                vmList.Add(ConvertENToViewModel(en));
            }

            return vmList;
        }
    }
}
