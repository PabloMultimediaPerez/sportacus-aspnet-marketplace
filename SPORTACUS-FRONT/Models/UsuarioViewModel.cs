using System;
using System.ComponentModel.DataAnnotations;

namespace SPORTACUS_FRONT.Models
{
    public class UsuarioViewModel
    {

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(100, ErrorMessage = "El nombre no puede exceder 100 caracteres")]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El email es obligatorio")]
        [EmailAddress(ErrorMessage = "El formato del email no es válido")]
        [StringLength(100, ErrorMessage = "El email no puede exceder 100 caracteres")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Range(600000000, 999999999, ErrorMessage = "Teléfono inválido")]
        [Display(Name = "Teléfono")]
        public int Telefono { get; set; }

        [StringLength(200, ErrorMessage = "La dirección no puede exceder 200 caracteres")]
        [Display(Name = "Dirección")]
        public string Direccion { get; set; }

        [Display(Name = "Fecha de Registro")]
        [DataType(DataType.DateTime)]
        public DateTime? FechaRegistro { get; set; }


        public bool EsAdministrador { get; set; }

        [Required(ErrorMessage = "La contraseña es obligatoriaaaa")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "La contraseña debe tener entre 6 y 100 caracteres")]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Pass { get; set; }
    }
}
