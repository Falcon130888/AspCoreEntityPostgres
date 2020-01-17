using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AspCoreEntityPostgres.Models;
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