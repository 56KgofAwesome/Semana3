using Semana3.Areas.Ejercicio7.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Semana3.Areas.Ejercicio7.Controllers
{
    public class HomeController : Controller
    {
        public string username;
        public string password;
        // GET: Ejercicio7/Home
        public ActionResult Index()
        {
            if(Session.Count == 0)
            {                
               return RedirectToAction("Login");
            }
            
            return View("Index");
        }
        //GET
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignUp()
        {   
            //Recibimos variables del formulario
            username = Request.Form["username"];
            password = Request.Form["password"];
            //Creamos una sesión
            if(username != null && username != "")
            {
                //Creamos la sesión y le asignamos la duración
                Session[username] = new Usuario() { username = username, password = password };                
                ViewBag.sessionName = username;
                return RedirectToAction("Index");
            }
            else
            {
                return View("Error");
            }
            
        }
        //Termina la sesión
        public ActionResult LogOut()
        {
            Session.Clear();
            return RedirectToAction("Index");
        }
    }
}