using SportacusGen.ApplicationCore.Enumerated.Sportacus;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SPORTACUS_FRONT.Models
{
    public class ProductoViewModel
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(100, ErrorMessage = "El nombre no puede exceder 100 caracteres")]
        [Display(Name = "Nombre")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "El email de usuario es obligatorio")]
        [Display(Name = "Email Usuario")]
        public string UsuarioEmail { get; set; }

        [Display(Name = "Usuario")]
        public string UsuarioNombre { get; set; }

        [Required(ErrorMessage = "La descripción es obligatoria")]
        [StringLength(500, ErrorMessage = "La descripción no puede exceder 500 caracteres")]
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "El precio es obligatorio")]
        [Range(minimum: 0.01, maximum: double.MaxValue, ErrorMessage = "El precio debe ser mayor que 0")]
        [Display(Prompt =  "Introduce el precio del producto", Description = "Precio del articulo", Name = "Precio")]
        [DataType(DataType.Currency, ErrorMessage = "El precio debe ser un valor numérico")]
        public double Precio { get; set; }

        [Required(ErrorMessage = "La categoría es obligatoria")]
        [Display(Name = "Categoría")]
        public CategoriaEnum Categoria { get; set; }

        [Required(ErrorMessage = "El estado es obligatorio")]
        [Display(Name = "Estado")]
        public EstadoProductoEnum Estado { get; set; }

        [Display(Name = "Fecha de Publicacion")]
        [DataType(DataType.DateTime)]
        public DateTime? FechaPublicacion { get; set; }

        public bool Disponible { get; set; }

        // URL de la imagen principal del producto (primera imagen asociada)
        public string ImagenUrlPrincipal { get; set; }

        // Lista de URLs de todas las imágenes asociadas al producto
        public IList<string> ImagenesUrls { get; set; }

        // Indica si el producto está en los favoritos del usuario logado
        public bool EsFavorito { get; set; }

    }
}
