﻿using System;
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
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;

namespace AspCoreEntityPostgres.Controllers
{
    public class HomeController : Controller
    {

        private readonly ApplicationContext db;
        public HomeController(ApplicationContext context)
        {
            db = context;
        }

        [Authorize]
        public IActionResult Index()
        {
            ViewData["Users"] = db.Users.ToList();
            ViewData["UserFIO"] = User.Identity.Name;
            return View();
           // return View(db.Users.ToList());
           // return Content(User.Identity.Name);
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync().ConfigureAwait(false);
            return RedirectToAction("Index", "Home");
        }

        //public IActionResult Index()
        //{
        //    //HtmlToPdfConverter converter = new HtmlToPdfConverter();
        //    //WebKitConverterSettings settings = new WebKitConverterSettings();
        //    ////Set WebKit path
        //    //settings.WebKitPath = Path.Combine(_hostingEnvironment.ContentRootPath, "QtBinariesWindows");

        //    //converter.ConverterSettings = settings;
        //    ////Convert URL to PDF
        //    //PdfDocument document = converter.Convert("https://localhost:44359/Home/Index");
        //    //MemoryStream stream = new MemoryStream();
        //    //document.Save(stream);
        //    //return File(stream.ToArray(), System.Net.Mime.MediaTypeNames.Application.Pdf, "Output.pdf");

        //    return View(db.Users.ToList());
        //}

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public IActionResult NewTask(int? IdUser)
        {
            if (IdUser == null) return RedirectToAction("Index");
            ViewBag.IdUser = IdUser;
            return View();
        }

        [HttpPost]
        public string NewTask(Models.Task task)
        {

            db.Tasks.Add(task);
            // сохраняем в бд все изменения
            db.SaveChanges();
            if (task !=null) return "Задача, " + task.NameTask + ", создана!";
            return "не удалось создать задачу!";
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
