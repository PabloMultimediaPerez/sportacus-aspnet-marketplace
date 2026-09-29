using System;
using System.ComponentModel.DataAnnotations;

namespace SPORTACUS_FRONT.Models
{
    public class ImagenViewModel
    {
        [Display(Name = "ID")]
        public int Id { get; set; }

        [Required(ErrorMessage = "El ID de producto es obligatorio")]
        [Display(Name = "ID Producto")]
        public int ProductoId { get; set; }

        [Display(Name = "Producto")]
        public string ProductoNombre { get; set; }

        [StringLength(200, ErrorMessage = "La descripción no puede exceder 50 caracteres")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "La URL es obligatoria")]
        [StringLength(500, ErrorMessage = "La URL no puede exceder 500 caracteres")]
        [Display(Name = "URL")]
        public string Url { get; set; }

        [Display(Name = "Fecha de Subida")]
        [DataType(DataType.DateTime)]
        public DateTime? FechaSubida { get; set; }
    }
}
