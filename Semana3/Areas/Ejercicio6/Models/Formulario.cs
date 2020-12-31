using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Semana3.Areas.Ejercicio6.Models
{
    public class Formulario
    {
        [Required(ErrorMessage = "El nombre de usuario es requerido")]
        [Display (Name = "Usuario")]
        public string username { get; set; }

        [Required]
        [Display(Name ="Contraseña")]
        [StringLength(20, ErrorMessage = "La {0} debe ser de mínimo {2} caractéres", MinimumLength = 8)]
        [RegularExpression(@"^.*[a-zA-Z0-9!*@#$&()\\-`.+,\\]{8,}.*$", ErrorMessage = "La {0} debe ser de mínimo 8 caractéres, asegúrate de incluir mayúsculas, números y caractéres")]
        [DataType(DataType.Password)]
        public string password { get; set; }

        [Required]
        [Display (Name = "Tiempo de sesión en minutos")]
        [Range(0, 1440, ErrorMessage = "Límite excedido")]
        public int sessionTime { get; set; }

    }
}