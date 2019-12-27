using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AspCoreEntityPostgres.Models;
using Syncfusion.HtmlConverter;
using Syncfusion.Pdf;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using AspCoreEntityPostgres.DBcontext;

namespace AspCoreEntityPostgres.Controllers
{

    public class HomeController : Controller
    {
        ApplicationContext db;

        public HomeController(ApplicationContext context)
        {
            db = context;
        }

        public IActionResult Index()
        {
            //HtmlToPdfConverter converter = new HtmlToPdfConverter();
            //WebKitConverterSettings settings = new WebKitConverterSettings();
            ////Set WebKit path
            //settings.WebKitPath = Path.Combine(_hostingEnvironment.ContentRootPath, "QtBinariesWindows");

            //converter.ConverterSettings = settings;
            ////Convert URL to PDF
            //PdfDocument document = converter.Convert("https://localhost:44359/Home/Index");
            //MemoryStream stream = new MemoryStream();
            //document.Save(stream);
            //return File(stream.ToArray(), System.Net.Mime.MediaTypeNames.Application.Pdf, "Output.pdf");
            return View(db.Users.ToList());
        }

        public IActionResult Privacy()
        {
            return View();
        }


        [HttpGet]
        public IActionResult NewTask(int? id)
        {
            if (id == null) return RedirectToAction("Index");
            ViewBag.IdUser = id;
            return View();
        }

        [HttpPost]
        public string NewTask(Models.Task task)
        {
            task.Id = 1;
            task.IdUser = 1;
            task.DateBegin = DateTime.Now;
            task.DateEnd = DateTime.Now;
            task.NameTask = "123123";
            task.TypeTask = "312312";

            db.Tasks.Add(task);
            // сохраняем в бд все изменения
            db.SaveChanges();
            return "Спасибо, " + task.NameTask + ", за покупку!";
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
