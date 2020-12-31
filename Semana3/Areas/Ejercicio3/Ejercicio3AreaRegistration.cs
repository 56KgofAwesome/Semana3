using System.Web.Mvc;

namespace Semana3.Areas.Ejercicio3
{
    public class Ejercicio3AreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Ejercicio3";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Ejercicio3_default",
                "Ejercicio3/{controller}/{action}/{id}",
                new { controller="Home", action = "Index", id = UrlParameter.Optional },
                new[] { "Semana3.Areas.Ejercicio3.Controllers" }
            );
        }
    }
}