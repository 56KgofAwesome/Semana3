using System.Web.Mvc;

namespace Semana3.Areas.Ejercicio8
{
    public class Ejercicio8AreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Ejercicio8";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Ejercicio8_default",
                "Ejercicio8/{controller}/{action}/{id}",
                new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                new [] { "Semana3.Areas.Ejercicio8.Controllers" }
            );
        }
    }
}