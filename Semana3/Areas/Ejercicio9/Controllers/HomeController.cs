using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Semana3.Areas.Ejercicio9.Controllers
{
    public class HomeController : Controller
    {
        // GET: Ejercicio9/Home
        public ActionResult Index()
        {
            return RedirectToAction("Create");
        }
        //GET
        public ActionResult Create()
        {
            return View();
        }
        //Recepción de los datos
        [HttpPost]
        public ActionResult CreateCard(Card card)
        {   
            //Datos de la vista
            ViewBag.name = card.name;
            ViewBag.addressOne = card.suburb + ", " + card.street + ", " + card.apartment;
            ViewBag.addressTwo = card.state + ", " + card.city + ", " + card.postalCode;
            ViewBag.phoneNumber = card.phoneNumber;
            ViewBag.email = card.email;
            //Datos de la ruta con imagen aleatoria
            string[] filePaths;            
            if (card.path == "1")
            {   
                filePaths = Directory.GetFiles(@"C:\Users\Dev14\source\repos\Semana3\Semana3\Areas\Ejercicio9\Images\Enterprise\", "*.jpg");
            }
            else
            {
                filePaths = Directory.GetFiles(@"C:\Users\Dev14\source\repos\Semana3\Semana3\Areas\Ejercicio9\Images\Casual\", "*.jpg");
            }
            Random rnd = new Random();
            int number = rnd.Next(1,3);
            string randomImage = filePaths[number];
            
            ViewBag.src = randomImage;

            return View();
        }

        //View de la carta de presentación
        public ActionResult Card()
        {   
            return View();
        }

    }
}