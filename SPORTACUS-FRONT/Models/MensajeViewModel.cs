using System;
using System.ComponentModel.DataAnnotations;
using SportacusGen.ApplicationCore.Enumerated;
using SportacusGen.ApplicationCore.Enumerated.Sportacus;

namespace SPORTACUS_FRONT.Models
{
    public class MensajeViewModel
    {
        [Display(Name = "ID")]
        public int Id { get; set; }

        [Display(Name = "Email Emisor")]
        public string? EmisorEmail { get; set; }

        [Display(Name = "Email Receptor")]
        public string? ReceptorEmail { get; set; }

        [Display(Name = "Emisor")]
        public string EmisorNombre { get; set; }

        [Display(Name = "Receptor")]
        public string ReceptorNombre { get; set; }

        [Required(ErrorMessage = "El contenido es obligatorio")]
        [StringLength(1000, ErrorMessage = "El contenido no puede exceder 1000 caracteres")]
        [Display(Name = "Contenido")]
        public string Contenido { get; set; }

        [Display(Name = "Fecha de Envío")]
        [DataType(DataType.DateTime)]
        public DateTime? FechaEnvio { get; set; }

        [Display(Name = "Tipo de Mensaje")]
        public TipoMensajeEnum TipoMensaje { get; set; }

        [StringLength(500, ErrorMessage = "La URL no puede exceder 500 caracteres")]
        [Display(Name = "URL Multimedia")]
        public string UrlMultimedia { get; set; }

        [Display(Name = "Leído")]
        public bool Leido { get; set; }


    }
}
