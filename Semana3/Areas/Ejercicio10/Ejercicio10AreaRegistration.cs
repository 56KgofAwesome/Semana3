using System.Web.Mvc;

namespace Semana3.Areas.Ejercicio10
{
    public class Ejercicio10AreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Ejercicio10";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Ejercicio10_default",
                "Ejercicio10/{controller}/{action}/{id}",
                new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                new[] { "Semana3.Areas.Ejercicio10.Controllers"}
            );
        }
    }
}