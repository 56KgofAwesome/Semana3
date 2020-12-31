using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Semana3.Areas.Ejercicio4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace Semana3.Areas.Ejercicio4.Controllers
{
    public class HomeController : Controller
    {
        public String path = @"C:\Users\Dev14\source\repos\Semana3\Semana3\Areas\Ejercicio4\Files\agenda.txt";
        public bool allowed = true;

        // GET: Ejercicio4/Home
        public ActionResult Index()
        {
            return View();
        }
        //Read the file
        public ActionResult readFile() {

            List<string> agenda = new List<string>();

            
            var agendaFile = System.IO.File.ReadAllLines(path);
            foreach (var task in agendaFile) 
            {
                agenda.Add(task);
            }
            agenda.ToList();
            var json = JsonConvert.SerializeObject(agenda);

            return Json(agenda);
        }

        // GET: Ejercicio4/Home/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Ejercicio4/Home/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ejercicio4/Home/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                allowed = true;
                //Se reciben los datos de la actividad
                ActivityClass activity = new ActivityClass();
                activity.activityType = collection["activityType"];
                activity.scheduledDate = collection["scheduledDate"];
                activity.scheduledTime = collection["scheduledTime"];
                activity.activityPeriod = collection["activityPeriod"];
                activity.activityNote = collection["activityNote"];
                //Guardamos en un JSON
                string activityJson = JsonConvert.SerializeObject(activity);

                //Verificar que la fecha ni hora esten ocupadas
                var agendaFile = System.IO.File.ReadAllLines(path);
                foreach (var task in agendaFile)
                {
                    //Serializamos el JSON de las actividades
                    JavaScriptSerializer js = new JavaScriptSerializer();
                    ActivityClass taskObject = js.Deserialize<ActivityClass>(task);
                    //
                    if(activity.scheduledDate == taskObject.scheduledDate)
                    {
                        //Creamos formato Datetime de los datos de la nueva actividad
                        var activityFullDate = activity.scheduledDate + " " +activity.scheduledTime;
                        DateTime activityStart = Convert.ToDateTime(activityFullDate);
                        //Agregamos los minutos de duración
                        var activityEnd = activityStart.AddMinutes(Convert.ToDouble(activity.activityPeriod));

                        //Creamos formato Datetime de los datos de la actividad revisada
                        var taskFullDate = taskObject.scheduledDate + " " + taskObject.scheduledTime;
                        DateTime taskStart = Convert.ToDateTime(taskFullDate);
                        //Agregamos los minutos de duración
                        var taskEnd = taskStart.AddMinutes(Convert.ToDouble(taskObject.activityPeriod));

                        //Verificamos el rango de horas de actividad
                        if(activityEnd < taskStart && activityStart > taskEnd)
                        {

                        }
                        else
                        {
                            allowed = false;
                            ViewBag.allowed = allowed;
                            return View();
                        }

                    }
                }

                var str = JToken.Parse(activityJson).ToString();
                //Guardamos en el archivo en una nueva línea
                System.IO.File.AppendAllText(path, activityJson + Environment.NewLine);
                
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult getFileData()
        {
            //Leer el archivo con las fechas
            string text = System.IO.File.ReadAllText(path);
       
            
            

            return Json(text.ToArray(), JsonRequestBehavior.AllowGet);
        }

        // GET: Ejercicio4/Home/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Ejercicio4/Home/Edit/5
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

        // GET: Ejercicio4/Home/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Ejercicio4/Home/Delete/5
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
