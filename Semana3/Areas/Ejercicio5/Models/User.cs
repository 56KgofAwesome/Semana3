using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Semana3.Areas.Ejercicio5.Models
{
    public class User
    {
        [Required]
        [Display(Name ="Nombre")]
        [RegularExpression(@"^/  +/g$")]
        public string name { get; set; }
        [Required]
        [Display(Name = "Correo electrónico")]
        [EmailAddress(ErrorMessage = "Ingrese un email válido")]
        public string email { get; set; }
        [Required]
        [Display(Name = "Expiración de la sesión")]
        public DateTime expirationDate { get; set; }

    }
}