using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Semana3.Areas.Ejercicio3.Models
{
    public class Comments
    {
        public String Id { get; set; }

        [DisplayName("Nombre")]
        [Required]
        public String name { get; set; }

        [DisplayName("País")]
        [Required]
        public String country { get; set; }

        [DisplayName("Comentario")]
        [Required]
        public String comment { get; set; }

    }
}