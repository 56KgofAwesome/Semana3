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
                //Cookies con sus preferencias por Default                
                HttpCookie cookies = new HttpCookie(username);
                cookies["sports"] = "true";
                cookies["politics"] = "true";
                cookies["cultural"] = "true";
                Response.Cookies.Add(cookies);
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
        //Preferencias de Cookies
        public ActionResult Settings()
        {            
            return View();
        }
        //Cambia las preferencias de noticias
        [HttpPost]
        public ActionResult ChangeSettings()
        {
            if (Request.Form["politics"] != null)
            {
                if (Request.Form["sports"] != null)
                {
                    if (Request.Form["cultural"] != null)
                    {
                        username = Session.Keys[0];
                        HttpCookie cookies = new HttpCookie(username);
                        cookies["politics"] = "true";
                        cookies["sports"] = "true";
                        cookies["cultural"] = "true";
                        Response.Cookies.Add(cookies);
                    }
                    else
                    {
                        username = Session.Keys[0];
                        HttpCookie cookies = new HttpCookie(username);
                        cookies["politics"] = "true";
                        cookies["sports"] = "true";
                        cookies["cultural"] = "false";
                        Response.Cookies.Add(cookies);
                    }
                }
                else
                {
                    if (Request.Form["cultural"] != null)
                    {
                        username = Session.Keys[0];
                        HttpCookie cookies = new HttpCookie(username);
                        cookies["politics"] = "true";
                        cookies["sports"] = "false";
                        cookies["cultural"] = "true";
                        Response.Cookies.Add(cookies);
                    }
                    else
                    {
                        username = Session.Keys[0];
                        HttpCookie cookies = new HttpCookie(username);
                        cookies["politics"] = "true";
                        cookies["sports"] = "false";
                        cookies["cultural"] = "false";
                        Response.Cookies.Add(cookies);
                    }
                }
            }
            else
            {
                if (Request.Form["sports"] != null)
                {
                    if(Request.Form["cultural"] != null)
                    {
                        username = Session.Keys[0];
                        HttpCookie cookies = new HttpCookie(username);
                        cookies["politics"] = "false";
                        cookies["sports"] = "true";
                        cookies["cultural"] = "true";
                        Response.Cookies.Add(cookies);
                    }
                    else
                    {
                        username = Session.Keys[0];
                        HttpCookie cookies = new HttpCookie(username);
                        cookies["politics"] = "false";
                        cookies["sports"] = "true";
                        cookies["cultural"] = "false";
                        Response.Cookies.Add(cookies);
                    }
                }
                else
                {
                    if (Request.Form["cultural"] != null)
                    {
                        username = Session.Keys[0];
                        HttpCookie cookies = new HttpCookie(username);
                        cookies["politics"] = "false";
                        cookies["sports"] = "false";
                        cookies["cultural"] = "true";
                        Response.Cookies.Add(cookies);
                    }
                    else
                    {
                        username = Session.Keys[0];
                        HttpCookie cookies = new HttpCookie(username);
                        cookies["sports"] = "false";
                        cookies["politics"] = "false";
                        cookies["cultural"] = "false";
                        Response.Cookies.Add(cookies);
                    }
                }
            }

            return RedirectToAction("Index");
        }
    }
}