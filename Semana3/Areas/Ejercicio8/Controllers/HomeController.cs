using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Semana3.Areas.Ejercicio8.Controllers
{
    public class HomeController : Controller
    {
        private static Random random = new Random();
        private string captchaText;
        private int width = 400;
        private int height = 100;
        private Random rnd = new Random();
        // GET: Ejercicio8/Home
        public ActionResult Index()
        {
            //Generamos un captcha inicial
            string firstCaptcha = RandomString();
            ViewBag.captchaText = firstCaptcha;
            string captcha = generateCaptchaImage(firstCaptcha);
            ViewBag.src = captcha;            
            return View();
        }
        //Formato del Captcha
        [HttpPost]
        public ActionResult FormatCaptcha(string letters = "true", string numbers = "true")
        {
            string rs = RandomString();
            //Recibimos valores del formulario
            string l = Request.Form["letters"] != null ? Request.Form["letters"] : "false";
            string n = Request.Form["numbers"] != null ? Request.Form["numbers"] : "false";
            //Ejecutamos la generación de Captcha requerida
            
            if(l == "false" && n == "true")
            {
                 rs = RandomString(1);
            }
            if (l == "true" && n == "false")
            {
                 rs = RandomString(2);
            }
            ViewBag.captchaText = rs;
            string source = generateCaptchaImage(rs);
            ViewBag.src = source;
            return View("Index");
        }
        //Genera la imagen de un captcha con el String solicitado
        private string generateCaptchaImage(string encodedText)
        {
            //First declare a bitmap and declare graphic from this bitmap
            Bitmap bitmap = new Bitmap(width, height, PixelFormat.Format32bppArgb);
            Graphics g = Graphics.FromImage(bitmap);
            //And create a rectangle to delegete this image graphic 
            Rectangle rect = new Rectangle(0, 0, width, height);
            //And create a brush to make some drawings
            HatchBrush hatchBrush = new HatchBrush(HatchStyle.DottedGrid, Color.Aqua, Color.White);
            g.FillRectangle(hatchBrush, rect);
            //here we make the text configurations
            GraphicsPath graphicPath = new GraphicsPath();
            //add this string to image with the rectangle delegate
            graphicPath.AddString(encodedText, FontFamily.GenericMonospace, (int)FontStyle.Bold, 90, rect, null);
            //And the brush that you will write the text
            hatchBrush = new HatchBrush(HatchStyle.Percent20, Color.Blue, Color.Black);
            g.FillPath(hatchBrush, graphicPath);
            //We are adding the dots to the image
            for (int i = 0; i < (int)(rect.Width * rect.Height / 50F); i++)
            {
                int x = rnd.Next(width);
                int y = rnd.Next(height);
                int w = rnd.Next(10);
                int h = rnd.Next(10);
                g.FillEllipse(hatchBrush, x, y, w, h);
            }
            //Remove all of variables from the memory to save resource
            hatchBrush.Dispose();
            g.Dispose();
            //return the image to the related component
            //return bitmap
            byte[] data = default(byte[]);

            using (System.IO.MemoryStream sampleStream = new System.IO.MemoryStream())
            {              
                bitmap.Save(sampleStream, System.Drawing.Imaging.ImageFormat.Bmp);
                //the byte array
                data = sampleStream.ToArray();
                string base64String = Convert.ToBase64String(data, 0, data.Length);
                return "data:image/png;base64," + base64String;
            }
        }
        //Random Captcha String        
        public static string RandomString(int option = 0)
        {
            const string letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            const string numbers = "0123456789";
            const string mixed = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

            switch (option)
            {
                //Sólo Ambos
                case 0:
                    string s1 = new string(Enumerable.Repeat(numbers, 3).Select(s => s[random.Next(s.Length)]).ToArray());
                    string s2 = new string(Enumerable.Repeat(letters, 3).Select(s => s[random.Next(s.Length)]).ToArray());
                    string fs = s2 + s1;
                    return fs;                    
                //Sólo Números  
                case 1:
                    return new string(Enumerable.Repeat(numbers, 6).Select(s => s[random.Next(s.Length)]).ToArray());                   
                //Letras   
                case 2:
                    return new string(Enumerable.Repeat(letters, 6).Select(s => s[random.Next(s.Length)]).ToArray());
                default:
                    return new string(Enumerable.Repeat(mixed, 6).Select(s => s[random.Next(s.Length)]).ToArray());
            }            
        }
    }
}