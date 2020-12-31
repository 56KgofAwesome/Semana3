using System.Web.Mvc;

namespace Semana3.Areas.Ejercicio4
{
    public class Ejercicio4AreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Ejercicio4";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Ejercicio4_default",
                "Ejercicio4/{controller}/{action}/{id}",
                new { controller="Home", action = "Index", id = UrlParameter.Optional },
                new [] { "Semana3.Areas.Ejercicio4.Controllers" }
            );
        }
    }
}