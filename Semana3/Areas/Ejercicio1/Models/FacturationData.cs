using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Semana3.Areas.Ejercicio1.Models
{
    public class FacturationData
    {
        [DisplayName("Fecha Inicial")]
        public DateTime initialDate { set; get; }

        [DisplayName("Fecha final")]
        public DateTime finalDate { set; get; }

        public periodTime selectedPeriod { set; get; }

        public enum periodTime {
            Mensual,
            Bimestral,
            Semestral,
            Anual
        }

        [DisplayName("Día de Corte")]       
        public int cutDay { set; get; }

        [DisplayName("Día de impresión")]
        public int printDay { set; get; }
    }
}