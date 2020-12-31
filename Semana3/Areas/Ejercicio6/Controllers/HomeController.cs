using Semana3.Areas.Ejercicio6.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Semana3.Areas.Ejercicio6.Controllers
{
    public class HomeController : Controller
    {
        // GET: Ejercicio6/Home
        public ActionResult Index()
        {   
            
            return View();
        }

        public ActionResult SignUp()
        {   

            if(Session["MySession"] != null && Session != null)
            {
                System.Web.HttpContext.Current.Session["MySession"] = "WELCOME";
                System.Web.HttpContext.Current.Session.Timeout = 1;
            }
            else
            {

            }
                
            return View();
        }
        [HttpPost]
        public ActionResult Register()
        {   
            //Recibimos los valores del formulario
            var username = Request.Form["username"];
            var password = Request.Form["password"];
            string sessionTime;
            if(Request.Form["sessionTime"] != null)
            {
                sessionTime = Request.Form["sessionTime"];
            }
            else
            {
                sessionTime = "5";
            }
           
            

            //Creamos la sesión y le asignamos la duración
            Session["MySession"] = new Formulario() { username = username, password = password, sessionTime = Convert.ToInt32(sessionTime)};
            Session.Timeout = Convert.ToInt32(sessionTime);

            //Retornar a Index con una sesión
            return RedirectToAction("Index");
        }

        
    }
}