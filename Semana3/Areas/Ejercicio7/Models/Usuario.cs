using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Semana3.Areas.Ejercicio7.Models
{
    public class Usuario
    {   
        [Required(ErrorMessage = "El nombre de usuario es requerido")]
        [Display(Name = "Usuario")]
        public string username { get; set; }

        [Required(ErrorMessage = "No olvide ingresar su contraseña")]
        [Display(Name = "Contraseña")]
        [DataType(DataType.Password)]
        public string password { get; set; }
    }
}