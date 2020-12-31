using System.Web.Mvc;

namespace Semana3.Areas.Ejercicio6
{
    public class Ejercicio6AreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Ejercicio6";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Ejercicio6_default",
                "Ejercicio6/{controller}/{action}/{id}",
                new { controller="Home", action = "Index", id = UrlParameter.Optional },
                new [] { "Semana3.Areas.Ejercicio6.Controllers" }

            );
        }
    }
}