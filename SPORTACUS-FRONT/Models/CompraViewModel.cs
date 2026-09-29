using System;
using System.ComponentModel.DataAnnotations;
using SportacusGen.ApplicationCore.Enumerated.Sportacus;

namespace SPORTACUS_FRONT.Models
{
    public class CompraViewModel
    {
        [Display(Name = "ID")]
        public int Id { get; set; }

        [Display(Name = "Email Comprador")]
        public string EmailComprador { get; set; }

        [Display(Name = "Nombre Comprador")]
        public string NombreComprador { get; set; }

        [Display(Name = "Email Vendedor")]
        public string EmailVendedor { get; set; }

        [Display(Name = "Nombre Vendedor")]
        public string NombreVendedor { get; set; }

        [Display(Name = "Id Producto")]
        public int ProductoId { get; set; }

        [Display(Name = "Titulo Producto")]
        public string ProductoTitulo { get; set; }

        [Display(Name = "Imagen Producto")]
        public string ProductoImagenUrl { get; set; }

        [Display(Name = "Fecha de Inicio")]
        [DataType(DataType.DateTime)]
        public DateTime FechaInicio { get; set; }

        [Display(Name = "Fecha de Compra")]
        [DataType(DataType.DateTime)]
        public DateTime FechaCompra { get; set; }

        [Display(Name = "Estado Compra")]
        public EstadoTransaccionEnum EstadoCompra { get; set; }

        [StringLength(200, ErrorMessage = "La dirección de envío no puede exceder 200 caracteres")]
        [Display(Name = "Dirección de Envío")]
        public string DireccionEnvio { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "El precio final debe ser mayor que 0")]
        [Display(Name = "Precio Final")]
        [DataType(DataType.Currency)]
        public double PrecioFinal { get; set; }

        [Display(Name = "Método de Pago")]
        public MetodoPagoEnum MetodoPago { get; set; }
    }
}
