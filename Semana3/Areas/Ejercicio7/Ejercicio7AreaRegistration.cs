using System.Web.Mvc;

namespace Semana3.Areas.Ejercicio7
{
    public class Ejercicio7AreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Ejercicio7";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Ejercicio7_default",
                "Ejercicio7/{controller}/{action}/{id}",
                new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                new[] { "Semana3.Areas.Ejercicio7.Controllers" }
            );
        }
    }
}