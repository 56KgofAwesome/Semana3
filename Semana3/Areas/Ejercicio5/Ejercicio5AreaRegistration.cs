using System.Web.Mvc;

namespace Semana3.Areas.Ejercicio5
{
    public class Ejercicio5AreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Ejercicio5";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Ejercicio5_default",
                "Ejercicio5/{controller}/{action}/{id}",
                new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                new[] { "Semana3.Areas.Ejercicio5.Controllers" }
            );
        }
    }
}