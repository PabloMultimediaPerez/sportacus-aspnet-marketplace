using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SPORTACUS_FRONT.Assemblers;
using SPORTACUS_FRONT.Models;
using SportacusGen.ApplicationCore.CEN.Sportacus;
using SportacusGen.ApplicationCore.CP.Sportacus;
using SportacusGen.ApplicationCore.EN.Sportacus;
using SportacusGen.ApplicationCore.IRepository.Sportacus; // Asegúrate de tener el using correcto
using SportacusGen.ApplicationCore.Enumerated.Sportacus;
using SportacusGen.Infraestructure.CP;
using SportacusGen.Infraestructure.Repository.Sportacus;
using System;
using System.Collections.Generic;
using System.Linq;
using WebSportacus.Controllers; // Agrega esta línea si CompraRepository está en este namespace

namespace SPORTACUS_FRONT.Controllers
{
    public class CompraController : BasicController
    {
        private readonly CompraCEN _compraCEN;

        public CompraController()
        {
            _compraCEN = new CompraCEN(new CompraRepository()); // Usa la implementación concreta de ICompraRepository
        }

        // GET: Compra
        // modo = null  -> Compras (usuario es comprador)
        // modo = "ventas" -> Ventas (usuario es vendedor)
        public IActionResult Index(string modo)
        {
            try
            {
                SessionInitialize();

                CompraRepository compraRepo = new CompraRepository(session);
                CompraCEN compraCEN = new CompraCEN(compraRepo);

                // Email del usuario logado guardado en sesión
                string emailUsuario = HttpContext.Session.GetString("usuarioEmail");

                // Lista de compras/ventas para el usuario actual
                IList<CompraEN> listEN = new List<CompraEN>();

                if (!string.IsNullOrEmpty(emailUsuario))
                {
                    bool esVentas = string.Equals(modo, "ventas", StringComparison.OrdinalIgnoreCase);

                    // 1) Intentamos usar los métodos específicos del repositorio
                    if (esVentas)
                    {
                        // Ventas: compras donde el usuario es VENDEDOR
                        listEN = compraCEN.ObtenerVentasPorUsuario(emailUsuario);
                    }
                    else
                    {
                        // Compras: compras donde el usuario es COMPRADOR
                        listEN = compraCEN.ObtenerComprasPorUsuario(emailUsuario);
                    }

                    // 2) Si por cualquier motivo no obtenemos resultados, hacemos un filtrado en memoria
                    //    sobre todas las compras mientras la sesión NHibernate sigue abierta.
                    if (listEN == null || listEN.Count == 0)
                    {
                        var todas = compraCEN.ReadAll(0, -1) ?? new List<CompraEN>();

                        if (esVentas)
                        {
                            listEN = todas
                                .Where(c => c.Vendedor != null && c.Vendedor.Email == emailUsuario)
                                .ToList();
                        }
                        else
                        {
                            listEN = todas
                                .Where(c => c.Comprador != null && c.Comprador.Email == emailUsuario)
                                .ToList();
                        }
                    }
                }

                // Construimos los view models manualmente mientras la sesión NHibernate sigue abierta
                var listVM = new List<CompraViewModel>();

                foreach (var c in listEN)
                {
                    if (c == null) continue;

                    var vm = new CompraViewModel
                    {
                        Id = c.Id,
                        EmailComprador = c.Comprador?.Email,
                        NombreComprador = c.Comprador?.Nombre,
                        EmailVendedor = c.Vendedor?.Email,
                        NombreVendedor = c.Vendedor?.Nombre,
                        ProductoId = c.Producto != null ? c.Producto.Id : 0,
                        ProductoTitulo = c.Producto?.Titulo,
                        ProductoImagenUrl = (c.Producto != null && c.Producto.Imagen != null && c.Producto.Imagen.Any())
                            ? c.Producto.Imagen.First().Url
                            : null,
                        FechaInicio = c.FechaInicio ?? DateTime.MinValue,
                        FechaCompra = c.FechaVenta ?? DateTime.MinValue,
                        EstadoCompra = c.EstadoCompra,
                        PrecioFinal = c.PrecioFinal,
                        MetodoPago = c.MetodoPago
                    };

                    listVM.Add(vm);
                }

                SessionClose();

                return View(listVM);
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Error al cargar las compras: " + ex.Message;
                return View(new List<CompraViewModel>());
            }
        }

        // GET: Compra/Details/5
        public IActionResult Details(int id)
        {
            SessionInitialize();

            CompraRepository compraRepo = new CompraRepository(session);
            CompraCEN compraCEN = new CompraCEN(compraRepo);

            CompraEN compraEN = compraCEN.ReadOID(id);
            CompraViewModel compraVM = CompraAssembler.ConvertENToViewModel(compraEN);

            SessionClose();

            return View(compraVM);
        }

        // GET: Compra/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Compra/Comprar
        // Crea una compra directa desde la ficha de producto (dinero infinito) y genera una notificación
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Comprar(int productoId, string vendedorEmail, string productoTitulo, double precio)
        {
            try
            {
                // Usuario actual (comprador)
                var emailComprador = HttpContext.Session.GetString("usuarioEmail");
                if (string.IsNullOrEmpty(emailComprador))
                {
                    return RedirectToAction("Login", "Usuario");
                }

                // Crear la compra (sin comprobar saldo)
                CompraRepository compraRepo = new CompraRepository();
                CompraCEN compraCEN = new CompraCEN(compraRepo);
                int compraId = compraCEN.New_(
                    DateTime.Now,
                    precio,
                    productoId,
                    emailComprador,
                    vendedorEmail,
                    MetodoPagoEnum.tarjeta
                );

                // Marcar la compra como completada y el producto como no disponible
                var compraCP = new CompraCP(new SessionCPNHibernate());
                compraCP.CompletarCompra(compraId);

                // Crear notificación de compra para el comprador
                NotificacionRepository notificacionRepo = new NotificacionRepository();
                NotificacionCEN notificacionCEN = new NotificacionCEN(notificacionRepo);

                string titulo = "Compra realizada";
                string contenido = $"Has comprado '{productoTitulo}' por {precio:0.##}$.";

                notificacionCEN.New_(
                    titulo,
                    contenido,
                    DateTime.Now,
                    false,
                    TipoNotificacionEnum.compra,
                    emailComprador
                );

                // Notificación de venta para el vendedor
                string tituloVenta = "Has vendido un producto";
                string contenidoVenta = $"Has vendido '{productoTitulo}' por {precio:0.##}$.";

                notificacionCEN.New_(
                    tituloVenta,
                    contenidoVenta,
                    DateTime.Now,
                    false,
                    TipoNotificacionEnum.compra,
                    vendedorEmail
                );

                TempData["CompraOk"] = "Producto comprado con éxito.";
                return RedirectToAction("Index", new { modo = (string)null });
            }
            catch (Exception ex)
            {
                TempData["CompraError"] = "Error al realizar la compra: " + ex.Message;
                return RedirectToAction("Details", "Producto", new { id = productoId });
            }
        }

        // POST: Compra/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CompraViewModel compraVM)
        {
            try
            {
                if (compraVM == null)
                    throw new ArgumentNullException(nameof(compraVM));

                CompraRepository compraRepo = new CompraRepository();
                CompraCEN compraCEN = new CompraCEN(compraRepo);
                compraCEN.New_(compraVM.FechaInicio,
                                compraVM.PrecioFinal,
                                compraVM.ProductoId,
                                compraVM.EmailComprador,
                                compraVM.EmailVendedor,
                                compraVM.MetodoPago);

                return RedirectToAction(nameof(Index));

            }
            catch (Exception ex)
            {
                ViewBag.Error = "Error al crear la compra: " + ex.Message;
                return View(compraVM);
            }
        }

        // GET: Compra/Edit/5
        public IActionResult Edit(int id)
        {

            SessionInitialize();

            CompraRepository compraRepo = new CompraRepository(session);
            CompraCEN compraCEN = new CompraCEN(compraRepo);

            CompraEN compraEN = compraCEN.ReadOID(id);
            CompraViewModel compraVM = CompraAssembler.ConvertENToViewModel(compraEN);

            SessionClose();

            return View(compraVM);
        }

        // POST: Compra/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, CompraViewModel compraVM)
        {
            try
            {
                if (compraVM == null)
                    return BadRequest();

                if (id != compraVM.Id)
                {
                    // Mostrar por qué falla en vez de devolver NotFound sin contexto
                    ModelState.AddModelError("", $"Id de ruta ({id}) no coincide con Id del modelo ({compraVM.Id}).");
                    return View(compraVM);
                }
                CompraRepository compraRepo = new CompraRepository();
                CompraCEN compraCEN = new CompraCEN(compraRepo);
                compraCEN.Modify(compraVM.Id,
                                 compraVM.FechaInicio,
                                 compraVM.PrecioFinal,
                                 compraVM.EstadoCompra,
                                 compraVM.MetodoPago);

                return RedirectToAction(nameof(Index));

            }
            catch (Exception ex)
            {
                ViewBag.Error = "Error al editar la compra: " + ex.Message;
                return View(compraVM);
            }
        }

        // GET: Compra/Delete/5
        public IActionResult Delete(int id)
        {
            CompraRepository compraRepo = new CompraRepository();
            CompraCEN compraCEN = new CompraCEN(compraRepo);
            compraCEN.Destroy(id);

            return RedirectToAction(nameof(Index));
        }

        // POST: Compra/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            try
            {
                _compraCEN.Destroy(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Error al eliminar la compra: " + ex.Message;
                return RedirectToAction(nameof(Index));
            }
        }
    }
}