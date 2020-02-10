using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AspCoreEntityPostgres.DBcontext;
using AspCoreEntityPostgres.Models;
using AspCoreEntityPostgres.ViewModel;
using jsreport.AspNetCore;
using jsreport.Types;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
//using Syncfusion.DocIO;
//using Syncfusion.DocIO.DLS;
using System.Security.Claims;

namespace AspCoreEntityPostgres.Controllers
{
    public class UsersController : Controller
    {
        private readonly ApplicationContext _context;
        public IJsReportMVCService JsReportMVCService { get; }
        public UsersController(IJsReportMVCService jsReportMVCService, ApplicationContext context)
        {
            _context = context;
            JsReportMVCService = jsReportMVCService;
        }

        // GET: Users
        public IActionResult Index()
        {
            UserViewModel UVM = new UserViewModel
            {
                Otdels = new SelectList(_context.Otdels.ToList(), "IdOtdel", "NameOtdel"),
                Users = _context.Users.Include(u => u.Dolzh).Include(u => u.Otdel).Include(u => u.Role)
            };
            return View(UVM);
        }

        [HttpPost]
        //[MiddlewareFilter(typeof(JsReportPipeline))]
        public async Task<IActionResult> ReportAsync(int? IdUser)
        {
            User user = await _context.Users
            .Include(u => u.Dolzh)
            .Include(u => u.Otdel)
            .Include(u => u.Role)
            .FirstOrDefaultAsync(m => m.IdUser == IdUser).ConfigureAwait(false);

            //FileStream fileStream = new FileStream(@"Files/SZ1.docx", FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            //WordDocument document = new WordDocument(fileStream, FormatType.Automatic);
            //document.Replace("ToFIODolzh", user.UserFIO + " - " + user.Dolzh.NameDolzh, false, true);

            //var identity = (ClaimsIdentity)User.Identity;
            //document.Replace("ISP", identity.Name, false, true);

            //MemoryStream stream = new MemoryStream();
            //document.Save(stream, FormatType.Docx);
            //document.Close();
            //stream.Position = 0;
            ////Download Word document in the browser
            //return File(stream, "application/msword", "Служебная записка.docx");

            var contentDisposition = "attachment; filename=\"детали " + user.UserAdLogin + ".pdf\"";
            //HttpContext.JsReportFeature().Recipe(Recipe.ChromePdf)
            //                .OnAfterRender((r) => HttpContext.Response.Headers["Content-Disposition"] = contentDisposition);
            HttpContext.JsReportFeature().Recipe(Recipe.ChromePdf);
            return View(user);
        }

        // GET: Users/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var user = await _context.Users
                .Include(u => u.Dolzh)
                .Include(u => u.Otdel)
                .Include(u => u.Role)
                .FirstOrDefaultAsync(m => m.IdUser == id).ConfigureAwait(false);
            if (user == null)
            {
                return NotFound();
            }
            return View( user);
        }

        // GET: Users/Create
        public IActionResult Create()
        {
            int selectedIndex = _context.Otdels.First().IdOtdel;
            ViewData["IdOtdel"] = new SelectList(_context.Otdels, "IdOtdel", "NameOtdel", selectedIndex);
            ViewData["IdDolzh"] = new SelectList(_context.Dolzhs.Where(c => c.IdOtdel == selectedIndex), "IdDolzh", "NameDolzh");
            ViewData["IdRole"] = new SelectList(_context.Roles, "IdRole", "NameRole");
            return View();
        }

        public ActionResult GetItems(int id)
        {
            ViewData["IdDolzh"] = new SelectList(_context.Dolzhs.Where(c => c.IdOtdel == id), "IdDolzh", "NameDolzh");
            return PartialView();
        }

        //поиск по фио
        public ActionResult GetUsers(string id, int? idotdel)
        {

            UserViewModel UVM = new UserViewModel();
            if( idotdel != null)
            {
                    UVM.Users = _context.Users.Include(d => d.Dolzh).Include(o => o.Otdel).Include(u => u.Role).Where(d => d.IdOtdel == idotdel);
            }
            else
            {
                if(id == null)
                {
                    UVM.Users = _context.Users.Include(d => d.Dolzh).Include(o => o.Otdel).Include(u => u.Role);
                }
                else
                {
                    UVM.Users = _context.Users.Include(d => d.Dolzh).Include(o => o.Otdel).Include(u => u.Role).Where(fio => fio.UserFIO.Contains(id));
                }
            }
        
            return PartialView(UVM);
        }

        // POST: Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdUser,UserFIO,UserAdLogin,UserPassword,UserLogin,UserConf,IdOtdel,IdDolzh,IdRole")] User user)
        {
            if (ModelState.IsValid)
            {
                _context.Add(user);
                await _context.SaveChangesAsync().ConfigureAwait(false);
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        // GET: Users/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            ViewData["IdDolzh"] = new SelectList(_context.Dolzhs.Where( d => d.IdOtdel == user.IdOtdel), "IdDolzh", "NameDolzh", user.IdDolzh);
            ViewData["IdOtdel"] = new SelectList(_context.Otdels, "IdOtdel", "NameOtdel", user.IdOtdel);
            ViewData["IdRole"] = new SelectList(_context.Roles, "IdRole", "NameRole", user.IdRole);
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdUser,UserFIO,UserAdLogin,UserPassword,UserLogin,UserConf,IdOtdel,IdDolzh,IdRole")] User user)
        {
            if (id != user.IdUser)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (user.UserPassword == null) user.UserPassword = ""; // это исправить
                    _context.Update(user);
                    await _context.SaveChangesAsync().ConfigureAwait(false);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.IdUser))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        // GET: Users/Delete/5
        [Authorize(Roles = "Администратор")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users
                .Include(u => u.Dolzh)
                .Include(u => u.Otdel)
                .Include(u => u.Role)
                .FirstOrDefaultAsync(m => m.IdUser == id).ConfigureAwait(false);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var user = await _context.Users.FindAsync(id);
            _context.Users.Remove(user);
            await _context.SaveChangesAsync().ConfigureAwait(false);
            return RedirectToAction(nameof(Index));
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.IdUser == id);
        }
    }
}
