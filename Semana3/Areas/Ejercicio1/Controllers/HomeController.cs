using Semana3.Areas.Ejercicio1.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Semana3.Areas.Ejercicio1.Controllers
{
    public class HomeController : Controller
    {
        // GET: Ejercicio1/Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult FormData(FacturationData data)
        {
            //Variables
            DateTime initialDate = data.initialDate;
            DateTime finalDate = data.finalDate;
            DateTime printDate;
            DateTime finalDateOnList;
            int period = (int)data.selectedPeriod;
            int printDay = data.printDay;
            int cutDay = data.cutDay;
            //Listas con la información
            List<String> initialDates = new List<String>();
            List<String> finalDates = new List<String>();
            List<String> printDays = new List<String>();
            //Datos enviados
            ViewBag.initialDateText = initialDate.ToShortDateString();
            ViewBag.finalDateText = finalDate.ToShortDateString();
            ViewBag.cutDayText = cutDay.ToString();
            ViewBag.printDayText = printDay.ToString();

            daysToAdd(period);

            initialDates.Add(initialDate.ToShortDateString());
                    
            if (period == 1)
            {             
                double numberOfDaysBetweenDates = differenceBetweenDates(initialDate, finalDate);

                while (numberOfDaysBetweenDates >= 27)
                {
                    //Calcular la primer fecha final de corte
                    finalDateOnList = printDayFormatFinal(initialDate,cutDay);
                    //Agregamos la fecha final de corte a la lista
                    finalDates.Add(finalDateOnList.ToShortDateString());
                    printDays.Add(printDayFormat(finalDateOnList,printDay).ToShortDateString());
                    //Agregamos un día a la fecha final para obtener la segunda fecha inicial
                    initialDate = finalDateOnList.AddDays(1);
                    initialDates.Add(initialDate.ToShortDateString());
                    //Calculamos días restantes
                    numberOfDaysBetweenDates = differenceBetweenDates(initialDate, finalDate);


                    
                }
            }
            if (period == 2)
            {
                double numberOfDays = differenceBetweenDates(initialDate, finalDate);

                while (numberOfDays >= 60)
                {
                    initialDate = initialDate.AddMonths(2).AddDays(-1);//31-01-2021
                    finalDates.Add(initialDate.ToShortDateString());//se agrega a FF
                    printDate = printDayFormat(initialDate, printDay);
                    printDays.Add(printDate.ToShortDateString());
                    numberOfDays = differenceBetweenDates(initialDate, finalDate);
                    if (numberOfDays >= 27)
                    {
                        initialDate = initialDate.AddDays(1);//1-02-2021
                        initialDates.Add(initialDate.ToShortDateString());//se agrega a FI      
                    }
                }
            }
            if (period == 6)
            {
                double numberOfDays = differenceBetweenDates(initialDate, finalDate);

                while (numberOfDays >= 180)
                {
                    initialDate = initialDate.AddMonths(6).AddDays(-1);//31-01-2021
                    finalDates.Add(initialDate.ToShortDateString());//se agrega a FF
                    printDate = printDayFormat(initialDate, printDay);
                    printDays.Add(printDate.ToShortDateString());
                    numberOfDays = differenceBetweenDates(initialDate, finalDate);
                    if (numberOfDays >= 27)
                    {
                        initialDate = initialDate.AddDays(1);//1-02-2021
                        initialDates.Add(initialDate.ToShortDateString());//se agrega a FI      
                    }
                }
            }
            if (period == 12)
            {
                double numberOfDays = differenceBetweenDates(initialDate, finalDate);

                while (numberOfDays >= 363)
                {
                    initialDate = initialDate.AddMonths(12).AddDays(-1);//31-01-2021
                    finalDates.Add(initialDate.ToShortDateString());//se agrega a FF
                    printDate = printDayFormat(initialDate, printDay);
                    printDays.Add(printDate.ToShortDateString());
                    numberOfDays = differenceBetweenDates(initialDate, finalDate);
                    if (numberOfDays >= 27)
                    {
                        initialDate = initialDate.AddDays(1);//1-02-2021
                        initialDates.Add(initialDate.ToShortDateString());//se agrega a FI      
                    }
                }
            }

            ViewBag.printDays = printDays;
            ViewBag.initialDates = initialDates;
            ViewBag.finalDates = finalDates;
            return View();
        }
        //Construct printDay Date
        public DateTime printDayFormat(DateTime initialDate, int printDay)
        {
            int day = printDay;
            int month = initialDate.Month;
            int year = initialDate.Year;

            if(month == 2)
            {
                day = 29;
                if(printDay < day )
                {
                    day = printDay;
                }                
            }

            if (month == 04 || month == 06 || month == 09 || month == 11) {
                day = 30;
            }

            if (printDay < day)
            {
                day = printDay;
            }

            DateTime firstPrintDate = new DateTime(year, month, day);
            return firstPrintDate;

        }
        //-------Print Format FinalDates
        public DateTime printDayFormatFinal(DateTime finalDate, int cutDay)
        {
            int day = cutDay;
            int month = finalDate.Month;
            int year = finalDate.Year;

            if (month == 2)
            {
                day = 29;
                if (cutDay < day)
                {
                    day = cutDay;
                }
            }

            if (month == 04 || month == 06 || month == 09 || month == 11)
            {
                day = 30;
            }

            if (cutDay < day)
            {
                day = cutDay;
            }

            DateTime firstFinalDate = new DateTime(year, month, day);
            return firstFinalDate;

        }
        //Check Period
        public int daysToAdd(int period)
        {   
            if(period == 1)
            {
                ViewBag.periodText = "Mensual";
                return 30;
            }
            if (period == 2)
            {
                ViewBag.periodText = "Bimestral";
                return 60;
            }
            if (period == 6)
            {
                ViewBag.periodText = "Semestral";
                return 180;
            }
            if (period == 12)
            {
                ViewBag.periodText = "Anual";
                return 365;
            }
            
            return 30;
        }
        //Método para verificar la diferencia de días entre fechas
        private double differenceBetweenDates(DateTime firstDate, DateTime secondDate)
        {
            var numberOfDays = (secondDate - firstDate).TotalDays;
            return numberOfDays;
        }

        // GET: Ejercicio1/Home/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Ejercicio1/Home/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ejercicio1/Home/Create
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

        // GET: Ejercicio1/Home/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Ejercicio1/Home/Edit/5
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

        // GET: Ejercicio1/Home/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Ejercicio1/Home/Delete/5
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
