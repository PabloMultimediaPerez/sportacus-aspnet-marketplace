using Microsoft.AspNetCore.Mvc;
using SPORTACUS_FRONT.Assemblers;
using SPORTACUS_FRONT.Models;
using SportacusGen.ApplicationCore.CEN.Sportacus;
using SportacusGen.ApplicationCore.CP.Sportacus;
using SportacusGen.ApplicationCore.EN.Sportacus;
using SportacusGen.Infraestructure.CP;
using SportacusGen.Infraestructure.EN.Sportacus;
using SportacusGen.Infraestructure.Repository.Sportacus;
using System;
using System.Collections.Generic;
using WebSportacus.Controllers;
using Microsoft.AspNetCore.Http;
using System.Linq;


namespace SPORTACUS_FRONT.Controllers
{
    public class ProductoController : BasicController
    {
        private readonly ProductoCEN _productoCEN;
        public ProductoController()
        {
            _productoCEN = new ProductoCEN(new ProductoRepository());
        }

        // GET: Producto
        public IActionResult Index()
        {
            try
            {
                SessionInitialize();

                ProductoRepository productoRepo = new ProductoRepository(session);
                ProductoCEN prodcutoCEN = new ProductoCEN(productoRepo);

                IList<ProductoEN> listEN = prodcutoCEN.ReadAll(0, -1);

                IEnumerable<ProductoViewModel> listVM = ProductoAssembler.ConvertListENToViewModel(listEN).ToList();

                SessionClose();

                return View(listVM);
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Error al cargar los productos: " + ex.Message;
                return View(new List<ProductoViewModel>());
            }
        }

        // GET: Producto/Details/5
        public IActionResult Details(int id)
        {
            SessionInitialize();

            try
            {
                // 1. Obtenemos el producto
                ProductoRepository productoRepo = new ProductoRepository(session);
                ProductoCEN productoCEN = new ProductoCEN(productoRepo);

                ProductoEN productoEN = productoCEN.ReadOID(id);

                // Si el producto no existe, devolvemos 404
                if (productoEN == null)
                {
                    return NotFound();
                }

                // 2. Convertimos el ProductoEN en ProductoViewModel
                ProductoViewModel productoVM =
                    ProductoAssembler.ConvertENToViewModel(productoEN);

                // 3. Por defecto consideramos que NO es favorito
                productoVM.EsFavorito = false;

                // 4. Obtenemos el email del usuario que tiene iniciada sesión
                string emailUsuario =
                    HttpContext.Session.GetString("usuarioEmail");

                // 5. Si hay usuario logado, comprobamos si tiene
                // este producto entre sus favoritos
                if (!string.IsNullOrEmpty(emailUsuario))
                {
                    FavoritoRepository favoritoRepo =
                        new FavoritoRepository(session);

                    FavoritoCEN favoritoCEN =
                        new FavoritoCEN(favoritoRepo);

                    IList<FavoritoEN> favoritosProducto =
                        favoritoCEN.ObtenerFavoritosPorProducto(id);

                    productoVM.EsFavorito =
                        favoritosProducto != null &&
                        favoritosProducto.Any(f =>
                            f.Usuario != null &&
                            string.Equals(
                                f.Usuario.Email,
                                emailUsuario,
                                StringComparison.OrdinalIgnoreCase
                            ));
                }

                // 6. La vista recibe el producto con EsFavorito
                // ya calculado
                return View(productoVM);
            }
            finally
            {
                SessionClose();
            }
        }

        // GET: Producto/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Producto/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ProductoViewModel productoVM)
        {
            try { 
            
                if (productoVM == null)
                    throw new ArgumentNullException(nameof(productoVM));

                ProductoRepository productoRepo = new ProductoRepository();
                ProductoCEN productoCEN = new ProductoCEN(productoRepo);
                productoCEN.New_(productoVM.Titulo, productoVM.Descripcion, productoVM.Precio, productoVM.Estado, 
                    productoVM.Categoria, productoVM.FechaPublicacion, productoVM.Disponible, productoVM.UsuarioEmail);

                return RedirectToAction(nameof(Index));

            }
            catch (Exception ex)
            {
                ViewBag.Error = "Error al crear el producto: " + ex.Message;
                return View(productoVM);
            }
        }

        // GET: Producto/Edit/5
        public IActionResult Edit(int id)
        {
            SessionInitialize();

            ProductoRepository productoRepo = new ProductoRepository(session);
            ProductoCEN productoCEN = new ProductoCEN(productoRepo);

            ProductoEN productoEN = productoCEN.ReadOID(id);
            ProductoViewModel productoVM = ProductoAssembler.ConvertENToViewModel(productoEN);

            SessionClose();

            return View(productoVM);
        }

        // POST: Producto/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, ProductoViewModel productoVM)
        {
            try
            {
                if (productoVM == null)
                    return BadRequest();

                if (id != productoVM.Id)
                {
                    // Mostrar por qué falla en vez de devolver NotFound sin contexto
                    ModelState.AddModelError("", $"Id de ruta ({id}) no coincide con Id del modelo ({productoVM.Id}).");
                    return View(productoVM);
                }

                ProductoRepository productoRepo = new ProductoRepository();
                ProductoCEN productoCEN = new ProductoCEN(productoRepo);
                productoCEN.Modify(productoVM.Id, productoVM.Titulo, productoVM.Descripcion, productoVM.Precio, 
                    productoVM.Estado, productoVM.Categoria, productoVM.FechaPublicacion, productoVM.Disponible);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Error al editar el favorito: " + ex.Message;
                return View(productoVM);
            }
        }

        // GET: Producto/Delete/5
        public IActionResult Delete(int id)
        {
            ProductoRepository productoRepo = new ProductoRepository();
            ProductoCEN productoCEN = new ProductoCEN(productoRepo);

            productoCEN.Destroy(id);

            return RedirectToAction(nameof(Index));
        }

        // POST: Producto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            try
            {
                _productoCEN.Destroy(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Error al eliminar el producto: " + ex.Message;
                return RedirectToAction(nameof(Index));
            }
        }
    }
}
