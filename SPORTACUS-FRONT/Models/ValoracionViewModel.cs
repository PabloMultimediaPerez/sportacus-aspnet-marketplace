using System;
using System.ComponentModel.DataAnnotations;

namespace SPORTACUS_FRONT.Models
{
    public class ValoracionViewModel
    {
        [Display(Name = "ID")]
        public int Id { get; set; }

        [Required(ErrorMessage = "El ID de producto es obligatorio")]
        [Display(Name = "ID Producto")]
        public int ProductoId { get; set; }

        [Display(Name = "Producto")]
        public string ProductoNombre { get; set; }

        [Required(ErrorMessage = "El email del comprador es obligatorio")]
        [Display(Name = "Email Comprador")]
        public string EmailComprador { get; set; }

        [Display(Name = "Nombre Comprador")]
        public string NombreComprador { get; set; }

        [Required(ErrorMessage = "El email del vendedor obligatorio")]
        [Display(Name = "Email Vendedor")]
        public string EmailVendedor{ get; set; }

        [Display(Name = "Nombre Vendedor")]
        public string NombreVendedor { get; set; }

        [Required(ErrorMessage = "La puntuación es obligatoria")]
        [Range(1, 5, ErrorMessage = "La puntuación debe estar entre 1 y 5")]
        [Display(Name = "Puntuación")]
        public int Puntuacion { get; set; }

        [StringLength(500, ErrorMessage = "El comentario no puede exceder 500 caracteres")]
        [Display(Name = "Comentario")]
        public string Comentario { get; set; }

        [Display(Name = "Fecha de Valoración")]
        [DataType(DataType.DateTime)]
        public DateTime? FechaValoracion { get; set; }

    }
}
