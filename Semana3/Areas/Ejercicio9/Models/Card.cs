using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Semana3.Areas.Ejercicio9
{
    public class Card
    {
        [Required(ErrorMessage = "El {0} es requerido")]
        [DataType(DataType.Text)]
        [Display(Name = "Nombre")]
        public string name { set; get; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Departamento")]
        public string apartment { set; get; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Calle")]
        public string street { set; get; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Colonia")]
        public string suburb { set; get; }

        [Required]
        [DataType(DataType.PostalCode)]
        [StringLength(5)]
        [Display(Name = "Código Postal")]
        public string postalCode { set; get; }

        [Required]
        [Display(Name = "Ciudad")]
        public string city { set; get; }

        [Required]
        [Display(Name = "Estado")]
        public string state { set; get; }

        [Required]
        [StringLength(10)]
        [Display(Name = "Teléfono")]
        public string phoneNumber { set; get; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Correo electrónico")]
        public string email { set; get; }

        [Required]
        [Display(Name = "Catálogo de imágenes")]
        public string path { set; get; }
    }
}