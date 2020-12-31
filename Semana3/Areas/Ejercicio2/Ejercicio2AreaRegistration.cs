using System.Web.Mvc;

namespace Semana3.Areas.Ejercicio2
{
    public class Ejercicio2AreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Ejercicio2";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Ejercicio2_default",
                "Ejercicio2/{controller}/{action}/{id}",
                new { controller="Home", action = "Index", id = UrlParameter.Optional },
                new[] { "Semana3.Areas.Ejercicio2.Controllers" }
            );
        }
    }
}