using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace SPORTACUS_FRONT.Models {
    public class LoginViewModel {

        // 1. Hemos cambiado DNI por Email
        [Display(Prompt = "Introduce el Email del Usuario", Description = "Email Usuario", Name = "Email")]
        [Required(ErrorMessage = "El Email del Usuario es obligatorio")]
        [EmailAddress(ErrorMessage = "El formato del email no es válido")] // Validacion extra recomendada
        public string Email { get; set; }

        // 2. Password (he añadido Required porque en un Login es obligatorio)
        [Display(Prompt = "Introduce el Password del Usuario", Description = "Password del Usuario", Name = "Contraseña")]
        [Required(ErrorMessage = "La contraseña es obligatoria")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}
