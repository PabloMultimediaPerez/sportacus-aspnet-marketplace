using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SPORTACUS_FRONT.Models;
using SportacusGen.ApplicationCore.CEN.Sportacus;
using SportacusGen.ApplicationCore.EN.Sportacus;
using SportacusGen.ApplicationCore.Enumerated.Sportacus;
using SportacusGen.Infraestructure.Repository.Sportacus;

namespace SPORTACUS_FRONT.Controllers
{
    public class HomeController : Controller
    {
        // search: texto del buscador superior
        // precioMin / precioMax: rango de precio
        // categoria: nombre del enum CategoriaEnum (ropa, calzado, ...)
        // estado: nombre del enum EstadoProductoEnum (nuevo, comoNuevo, ...)
        // fechaDesde: fecha mínima de publicación
        public IActionResult Index(string search, double? precioMin, double? precioMax,
                                   string categoria, string estado, DateTime? fechaDesde)
        {
            ProductoRepository productoRepository = new ProductoRepository();
            ProductoCEN productoCEN = new ProductoCEN(productoRepository);

			IList<ProductoEN> listaProd = productoCEN.ReadAll(0, -1);
			// Sólo mostramos productos disponibles (no vendidos/comprados)
			listaProd = listaProd.Where(p => p.Disponible).ToList();

			// Filtros en memoria sobre la lista
			if (!string.IsNullOrWhiteSpace(search))
			{
				var term = search.Trim();
				listaProd = listaProd
					.Where(p => (!string.IsNullOrEmpty(p.Titulo) && p.Titulo.Contains(term, StringComparison.OrdinalIgnoreCase))
						|| (!string.IsNullOrEmpty(p.Descripcion) && p.Descripcion.Contains(term, StringComparison.OrdinalIgnoreCase)))
					.ToList();
			}

			if (precioMin.HasValue)
			{
				listaProd = listaProd.Where(p => p.Precio >= precioMin.Value).ToList();
			}

			if (precioMax.HasValue)
			{
				listaProd = listaProd.Where(p => p.Precio <= precioMax.Value).ToList();
			}

			if (!string.IsNullOrEmpty(categoria) && Enum.TryParse<CategoriaEnum>(categoria, true, out var catEnum))
			{
				listaProd = listaProd.Where(p => p.Categoria == catEnum).ToList();
			}

			if (!string.IsNullOrEmpty(estado) && Enum.TryParse<EstadoProductoEnum>(estado, true, out var estEnum))
			{
				listaProd = listaProd.Where(p => p.Estado == estEnum).ToList();
			}

			if (fechaDesde.HasValue)
			{
				var fecha = fechaDesde.Value.Date;
				listaProd = listaProd
					.Where(p => p.FechaPublicacion.HasValue && p.FechaPublicacion.Value.Date >= fecha)
					.ToList();
			}

			return View(listaProd);
        }

        public IActionResult Privacy()
        {
			return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
