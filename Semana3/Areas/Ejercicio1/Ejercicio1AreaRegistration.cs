using System.Web.Mvc;

namespace Semana3.Areas.Ejercicio1
{
    public class Ejercicio1AreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Ejercicio1";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Ejercicio1_default",
                "Ejercicio1/{controller}/{action}/{id}",
                new { controller="Home", action = "Index", id = UrlParameter.Optional }, 
                new [] { "Semana3.Areas.Ejercicio1.Controllers" }
            );
        }
    }
}