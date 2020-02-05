using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AspCoreEntityPostgres.DBcontext;
using AspCoreEntityPostgres.Models;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using System.Security.Claims;

namespace AspCoreEntityPostgres.Controllers
{
    public class MemosController : Controller
    {
        private readonly ApplicationContext _context;
        IWebHostEnvironment _appEnvironment;

        public MemosController(ApplicationContext context, IWebHostEnvironment appEnvironment)
        {
            _context = context;
            _appEnvironment = appEnvironment;
        }

        // GET: Memos
        public async Task<IActionResult> Index()
        {
            var applicationContext = _context.Memos.Include(m => m.Status).Include(m => m.UserExecutor).Include(m => m.UserTO);
            return View(await applicationContext.ToListAsync().ConfigureAwait(false));
        }

        // GET: Memos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var memo = await _context.Memos
                .Include(m => m.Status)
                .Include(m => m.UserExecutor)
                .Include(m => m.UserTO)
                .Include(m => m.MemoFiles)
                .Include(m => m.MemoCopies).Include("MemoCopies.User")
                .FirstOrDefaultAsync(m => m.IdMemo == id).ConfigureAwait(false);
            if (memo == null)
            {
                return NotFound();
            }
            return View(memo);
        }

        // GET: Memos/Create
        public IActionResult Create()
        {
            ViewData["IdStatus"] = new SelectList(_context.Statuses, "IdStatus", "IdStatus", "Выберите сотрудника");
            ViewData["Users"] = new SelectList(_context.Users, "IdUser", "UserFIO");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(string Content, List<string> CopyItems, List<IFormFile> files, [Bind("IdMemo,DateCreate,DateEnd,IsActive,Thema,Content,IdStatus,IdUserTo,IdUserExecutor")] Memo memo)
        {
            string IdUser = HttpContext.User.Claims.FirstOrDefault(x => x.Type == "IdUser")?.Value;

            //string FilePath1 = Path.GetFileNameWithoutExtension(files[0].FileName);
            //FilePath1 = "/Files/Memos/" + FilePath1.Trim() + Path.GetExtension(files[0].FileName);
            //ModelState.AddModelError(String.Empty, _appEnvironment.WebRootPath + FilePath1);
            //return View();

            memo.IsActive = true;
            memo.IdStatus = 1;
            if (IdUser != null)
            {
                memo.IdUserExecutor = Convert.ToInt32(IdUser);
            }

            if (ModelState.IsValid)
            {
                _context.Add(memo);
                await _context.SaveChangesAsync().ConfigureAwait(false);

                foreach (IFormFile file in files)
                {
                    if (file.Length > 0)
                    {
                        MemoFile memoFile = new MemoFile();

                        string FilePath = Path.GetFileNameWithoutExtension(file.FileName);
                        string FileExtension = Path.GetExtension(file.FileName);
                        FilePath = "\\Files\\Memos\\" + memo.IdMemo.ToString() + "-" + FilePath.Trim() + FileExtension;

                        // сохраняем файл в папку Files в каталоге wwwroot
                        using var fileStream = new FileStream(_appEnvironment.WebRootPath + FilePath, FileMode.Create);
                        await file.CopyToAsync(fileStream).ConfigureAwait(false);

                        memoFile.IdMemo = memo.IdMemo;
                        memoFile.Format = FileExtension;
                        memoFile.FileName = file.FileName;
                        memoFile.Path = FilePath;
                        _context.Add(memoFile);
                        await _context.SaveChangesAsync().ConfigureAwait(false);
                    }
                }
                
                foreach (string IdCopy in CopyItems)
                {
                    MemoCopy copy = new MemoCopy
                    {
                        IdUser = _context.Users.FirstOrDefault(x => x.IdUser == Convert.ToInt32(IdCopy)).IdUser ,
                        IdMemo = memo.IdMemo
                    };
                 _context.Add(copy);
                 await _context.SaveChangesAsync().ConfigureAwait(false);
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdStatus"] = new SelectList(_context.Statuses, "IdStatus", "IdStatus");
            ViewData["Users"] = new SelectList(_context.Users, "IdUser", "UserFIO");
            return View(memo);
        }

        // Download file
        public FileResult Download(int id)
        {
            MemoFile memoFile = _context.MemoFiles.FirstOrDefault(m => m.IdMemoFile == id);
            byte[] fileBytes = System.IO.File.ReadAllBytes(_appEnvironment.WebRootPath + memoFile.Path);
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, memoFile.FileName);
        }

        // GET: Memos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var memo = await _context.Memos.FindAsync(id);
            if (memo == null)
            {
                return NotFound();
            }
            ViewData["IdStatus"] = new SelectList(_context.Statuses, "IdStatus", "NameStatus", memo.IdStatus);
            ViewData["IdUserExecutor"] = new SelectList(_context.Users, "IdUser", "UserFIO", memo.IdUserExecutor);
            ViewData["IdUserTo"] = new SelectList(_context.Users, "IdUser", "UserFIO", memo.IdUserTo);
            return View(memo);
        }

        // POST: Memos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdMemo,DateCreate,DateEnd,IsActive,Thema,Content,IdStatus,IdUserTo,IdUserExecutor")] Memo memo)
        {
            if (id != memo.IdMemo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(memo);
                    await _context.SaveChangesAsync().ConfigureAwait(false);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MemoExists(memo.IdMemo))
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
            ViewData["IdStatus"] = new SelectList(_context.Statuses, "IdStatus", "IdStatus", memo.IdStatus);
            ViewData["IdUserExecutor"] = new SelectList(_context.Users, "IdUser", "IdUser", memo.IdUserExecutor);
            ViewData["IdUserTo"] = new SelectList(_context.Users, "IdUser", "IdUser", memo.IdUserTo);
            return View(memo);
        }

        // GET: Memos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var memo = await _context.Memos
                .Include(m => m.Status)
                .Include(m => m.UserExecutor)
                .Include(m => m.UserTO)
                .FirstOrDefaultAsync(m => m.IdMemo == id).ConfigureAwait(false);
            if (memo == null)
            {
                return NotFound();
            }

            return View(memo);
        }

        // POST: Memos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            IEnumerable<MemoFile> memoFiles = _context.MemoFiles.Where(x => x.IdMemo == id);
            foreach (var MemoFile in memoFiles)
            {
                if (System.IO.File.Exists(_appEnvironment.WebRootPath + MemoFile.Path))
                {
                    System.IO.File.Delete(_appEnvironment.WebRootPath + MemoFile.Path);
                }
            }
            var memo = await _context.Memos.FindAsync(id);
            _context.Memos.Remove(memo);
            await _context.SaveChangesAsync().ConfigureAwait(false);
            return RedirectToAction(nameof(Index));
        }

        private bool MemoExists(int id)
        {
            return _context.Memos.Any(e => e.IdMemo == id);
        }
    }
}