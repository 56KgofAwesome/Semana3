using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Semana3.Areas.Ejercicio5.Controllers
{
    public class HomeController : Controller
    {
        // GET: Ejercicio5/Home
        public ActionResult Index()
        {
            var userName = Request.Cookies["nameUser"];
            var emailUser = Request.Cookies["emailUser"];
            var expirationDate = Request.Cookies["expirationDate"];

            if(userName != null || emailUser != null || expirationDate != null)
            {
                ViewBag.userNameView = userName.Value;
                ViewBag.emailUserView = emailUser.Value;
                ViewBag.expirationDateView = expirationDate.Value;
                return View("Welcome");
            }
            return View();
        }

        public ActionResult SignUp()
        {   
            return View();
        }

        [HttpPost]
        public ActionResult cookieSave()
        {            
            //Colección de cookies
            HttpCookieCollection userData = new HttpCookieCollection();
            //Cookies de los valores del formulario
            HttpCookie nameUser = new HttpCookie("nameUser");
            nameUser.Value = Request["nameUser"];
            HttpCookie emailUser = new HttpCookie("emailUser");
            emailUser.Value = Request["emailUser"];
            //Convertimos el string a DateTime para establecerlo en expirationDate
            string cookieExpirationString = Request["expirationDate"] + " " +Request["expirationHour"];
            DateTime expirationDateTime = Convert.ToDateTime(cookieExpirationString);
            HttpCookie expirationDate = new HttpCookie("expirationDate");
            expirationDate.Value = expirationDateTime.ToString();

            userData.Add(nameUser);
            userData.Add(emailUser);
            userData.Add(expirationDate);

            nameUser.Expires = expirationDateTime;
            emailUser.Expires = expirationDateTime;
            expirationDate.Expires = expirationDateTime;

            //Agregamos las cookies del CookieCollection
            for (var i=0; i < userData.Count; i++)
            {
                Response.Cookies.Add(userData[i]);
            }
            
            return RedirectToAction("Index","Home");
        }

        // GET: Ejercicio5/Home/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Ejercicio5/Home/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ejercicio5/Home/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Ejercicio5/Home/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Ejercicio5/Home/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Ejercicio5/Home/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Ejercicio5/Home/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
