using System;
using System.ComponentModel.DataAnnotations;
using SportacusGen.ApplicationCore.Enumerated;
using SportacusGen.ApplicationCore.Enumerated.Sportacus;

namespace SPORTACUS_FRONT.Models
{
    public class NotificacionViewModel
    {
        [Display(Name = "ID")]
        public int Id { get; set; }

        [Required(ErrorMessage = "El email de usuario es obligatorio")]
        [Display(Name = "Email Usuario")]
        public string UsuarioEmail { get; set; }

        [Display(Name = "Usuario")]
        public string UsuarioNombre { get; set; }

        [Required(ErrorMessage = "El tipo es obligatorio")]
        [Display(Name = "Tipo")]
        public TipoNotificacionEnum TipoNotificacion { get; set; }

        [Required(ErrorMessage = "El titulo es obligatorio")]
        [StringLength(500, ErrorMessage = "El titulo no puede exceder 20 caracteres")]
        [Display(Name = "Titulo")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "El contenido es obligatorio")]
        [StringLength(500, ErrorMessage = "El contenido no puede exceder 50 caracteres")]
        [Display(Name = "Contenido")]
        public string Contenido { get; set; }

        [Display(Name = "Fecha de Creación")]
        [DataType(DataType.DateTime)]
        public DateTime? FechaCreacion { get; set; }

        [Display(Name = "Leída")]
        public bool Leida { get; set; }

        // Id del mensaje asociado (para notificaciones de tipo mensaje)
        public int? MensajeId { get; set; }

        // Email del otro usuario implicado en la conversación, usado para navegar al chat
        public string OtroUsuarioEmail { get; set; }

    }
}
