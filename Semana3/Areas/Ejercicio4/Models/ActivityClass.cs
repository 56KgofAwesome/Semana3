using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Semana3.Areas.Ejercicio4.Models
{
    public class ActivityClass
    {
        
        public string activityType { get; set; }
        [Required]
        public string scheduledDate{ get; set; }
        [Required]
        public string scheduledTime { get; set; }
        public string activityPeriod { get; set; }
        [Required]
        public string activityNote { get; set; }
    }
}