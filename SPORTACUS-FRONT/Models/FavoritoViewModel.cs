using System;
using System.ComponentModel.DataAnnotations;
using SportacusGen.ApplicationCore.Enumerated;
using SportacusGen.ApplicationCore.Enumerated.Sportacus;

namespace SPORTACUS_FRONT.Models
{
    public class FavoritoViewModel
    {
        [Display(Name = "ID")]
        public int Id { get; set; }

        [Required(ErrorMessage = "El Email de usuario es obligatorio")]
        [Display(Name = "Email Usuario")]
        public string UsuarioEmail { get; set; }

        [Display(Name = "Nombre Usuario")]
        public string UsuarioNombre { get; set; }

        [Required(ErrorMessage = "El ID de producto es obligatorio")]
        [Display(Name = "Producto ID")]
        public int ProductoId { get; set; }

        [Display(Name = "Titulo Producto")]
        public string ProductoTitulo { get; set; }

        [Display(Name = "Imagen Producto")]
        public string ProductoImagenUrl { get; set; }

        [Display(Name = "Precio Producto")]
        public double ProductoPrecio { get; set; }

        [Display(Name = "Estado Producto")]
        public EstadoProductoEnum ProductoEstado { get; set; }

        [Display(Name = "Categoria Producto")]
        public CategoriaEnum ProductoCategoria { get; set; }

        [Display(Name = "Fecha de Agregado")]
        [DataType(DataType.DateTime)]
        public DateTime? FechaMarcado { get; set; }

    }
}
