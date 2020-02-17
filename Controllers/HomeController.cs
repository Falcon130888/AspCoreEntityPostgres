using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AspCoreEntityPostgres.Models;
using AspCoreEntityPostgres.DBcontext;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using System.Collections.Generic;
using System;
using Microsoft.EntityFrameworkCore;

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
            // Мои заявки 
            int IdUserLogin = Convert.ToInt32(HttpContext.User.Claims.FirstOrDefault(x => x.Type == "IdUser")?.Value);
            IEnumerable<Memo> Memos = db.Memos.Where(m => m.IdUserTo == IdUserLogin).Include(st => st.Status).Include(ex => ex.UserExecutor);
            return View(Memos);
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync().ConfigureAwait(false);
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}