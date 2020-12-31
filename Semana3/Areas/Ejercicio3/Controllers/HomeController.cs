using Semana3.Areas.Ejercicio3.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Semana3.Areas.Ejercicio3.Controllers
{
    public class HomeController : Controller
    {   
        public String path = @"C:\Users\Dev14\source\repos\Semana3\Semana3\Areas\Ejercicio3\Files\";
        public List<Comments> commentsList = new List<Comments> { };
     
        public int commentsListIndex;
        public int fileID;
        public List<string> fileContent = new List<string>();

       
        
        // GET: Ejercicio3/Home
        public ActionResult Index()
        {
            ListCommentsFromPath(commentsList);
            return View(commentsList);
        }
        //Get Comments from Path
        public List<Comments> ListCommentsFromPath(List<Comments> commentsList)
        {
            int fileCount = Directory.GetFiles(path).Length;
            ViewBag.files = fileCount;//Visualizar cuantos archivos hay
            if (fileCount > 0)
            {
                for (var i = 1; i <= fileCount; i++)
                {   //Recorrer los comentarios
                    //Agregar cada comentario a la lista
                    commentsList.Add(new Comments() { });
                    commentsListIndex = commentsList.Count() - 1;//Index de lista de comentarios
                    fileID = commentsListIndex + 1;//Index del nombre del archivo
                    foreach (string line in System.IO.File.ReadLines(path + fileID + ".txt"))
                    {
                        fileContent.Add(line);//Lista con el contenido del archivo
                    }
                    //Pobla el comentario de la lista con el contenido
                    commentsList[commentsListIndex].Id = fileContent[0];
                    commentsList[commentsListIndex].name = fileContent[1];
                    commentsList[commentsListIndex].country = fileContent[2];
                    commentsList[commentsListIndex].comment = fileContent[3];
                    fileContent.Clear();
                }
            }
            return commentsList;
        }

        // GET: Ejercicio3/Home/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Ejercicio3/Home/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ejercicio3/Home/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection,String lastId)
        {
            try
            {
                //Tomamos los valores del Formulario
                //String newId = collection[""]; //Recibir el ID del ultimo archivo y sumarle +1
                String newName = collection["name"];
                String newCountry = collection["country"];
                String newComment = collection["comment"];

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Ejercicio3/Home/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Ejercicio3/Home/Edit/5
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

        // GET: Ejercicio3/Home/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Ejercicio3/Home/Delete/5
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
