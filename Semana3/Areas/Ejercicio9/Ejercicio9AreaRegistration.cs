using System.Web.Mvc;

namespace Semana3.Areas.Ejercicio9
{
    public class Ejercicio9AreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Ejercicio9";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Ejercicio9_default",
                "Ejercicio9/{controller}/{action}/{id}",
                new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                new[] { "Semana3.Areas.Ejercicio9.Controllers" }

            );
        }
    }
}