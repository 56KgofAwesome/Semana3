using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Semana3.Areas.Ejercicio2.Controllers
{
    public class HomeController : Controller
    {
        // GET: Ejercicio2/Home
        public ActionResult Index()
        {
            return View();
        }
        //Imprime piramide de Pascal
        [HttpPost]
        public ActionResult pascalPiramid(int rows)
        {
            int i = 0;
            int Count = 0;
            int Cantidad = 0;
            int Columna = 0;
            int Fila = 0;

            Cantidad = rows;

            int[,] MAT = new int[Cantidad + 1, Cantidad + 1];
            //
            for (i = 1; i <= Cantidad; i++)
            {
                for (Count = 1; Count <= Cantidad; Count++)
                { 
                    if ((Count == 1) | (i == Count))
                    {
                        MAT[i, Count] = 1;
                    }
                    else
                    {
                        MAT[i, Count] = MAT[i - 1, Count] + MAT[i - 1, Count - 1];
                    }
                }
            }
            //
            Fila = 2;

            for (i = 1; i <= Cantidad; i++)
            {
                Columna = 40 - (i * 2);

                for (Count = 1; Count <= Cantidad; Count++)
                {
                    if (MAT[i, Count] != 0)
                    {
                        Console.SetCursorPosition(Columna, Fila);
                        Console.Write(MAT[i, Count]);
                        Columna = Columna + 4;
                    }
                }
                Fila = Fila + 1;
                ViewBag.fila = Fila;
                
            }
            return View();
        }

        // GET: Ejercicio2/Home/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Ejercicio2/Home/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ejercicio2/Home/Create
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

        // GET: Ejercicio2/Home/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Ejercicio2/Home/Edit/5
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

        // GET: Ejercicio2/Home/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Ejercicio2/Home/Delete/5
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
