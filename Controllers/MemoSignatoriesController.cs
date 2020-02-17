using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AspCoreEntityPostgres.DBcontext;
using AspCoreEntityPostgres.Models;

namespace AspCoreEntityPostgres.Controllers
{
    public class MemoSignatoriesController : Controller
    {
        private readonly ApplicationContext _context;

        public MemoSignatoriesController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: MemoSignatories
        public async Task<IActionResult> Index()
        {
            var applicationContext = _context.MemoSignatories.Include(m => m.Memo).Include(m => m.User);
            return View(await applicationContext.ToListAsync().ConfigureAwait(false));
        }

        // GET: MemoSignatories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var memoSignatory = await _context.MemoSignatories
                .Include(m => m.Memo)
                .Include(m => m.User)
                .FirstOrDefaultAsync(m => m.IdMemoSignatory == id).ConfigureAwait(false);
            if (memoSignatory == null)
            {
                return NotFound();
            }

            return View(memoSignatory);
        }

        // GET: MemoSignatories/Create
        public IActionResult Create()
        {
           var CountryList = Enum.GetNames(typeof(MemoSignatory.SignEnum)).Select(name => new SelectListItem()
            {
                Text = name,
                Value = name
            });

            ViewData["SignEnum"] = CountryList;
            ViewData["IdMemo"] = new SelectList(_context.Memos, "IdMemo", "IdMemo");
            ViewData["IdUser"] = new SelectList(_context.Users, "IdUser", "IdUser");
            return View();
        }

        // POST: MemoSignatories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdMemoSignatory,Sign,IdMemo,Comments,IdUser")] MemoSignatory memoSignatory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(memoSignatory);
                await _context.SaveChangesAsync().ConfigureAwait(false);
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdMemo"] = new SelectList(_context.Memos, "IdMemo", "IdMemo", memoSignatory.IdMemo);
            ViewData["IdUser"] = new SelectList(_context.Users, "IdUser", "IdUser", memoSignatory.IdUser);
            return View(memoSignatory);
        }

        // GET: MemoSignatories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var memoSignatory = await _context.MemoSignatories.FindAsync(id);
            if (memoSignatory == null)
            {
                return NotFound();
            }
            var CountryList = Enum.GetNames(typeof(MemoSignatory.SignEnum)).Select(name => new SelectListItem()
            {
                Text = name,
                Value = name
            });

            ViewData["SignEnum"] = CountryList;
            ViewData["IdMemo"] = new SelectList(_context.Memos, "IdMemo", "IdMemo", memoSignatory.IdMemo);
            ViewData["IdUser"] = new SelectList(_context.Users, "IdUser", "IdUser", memoSignatory.IdUser);
            return View(memoSignatory);
        }

        // POST: MemoSignatories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdMemoSignatory,Sign,IdMemo,Comments,IdUser")] MemoSignatory memoSignatory)
        {
            if (id != memoSignatory.IdMemoSignatory)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(memoSignatory);
                    await _context.SaveChangesAsync().ConfigureAwait(false);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MemoSignatoryExists(memoSignatory.IdMemoSignatory))
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
            ViewData["IdMemo"] = new SelectList(_context.Memos, "IdMemo", "IdMemo", memoSignatory.IdMemo);
            ViewData["IdUser"] = new SelectList(_context.Users, "IdUser", "IdUser", memoSignatory.IdUser);
            return View(memoSignatory);
        }

        // GET: MemoSignatories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var memoSignatory = await _context.MemoSignatories
                .Include(m => m.Memo)
                .Include(m => m.User)
                .FirstOrDefaultAsync(m => m.IdMemoSignatory == id).ConfigureAwait(false);
            if (memoSignatory == null)
            {
                return NotFound();
            }

            return View(memoSignatory);
        }

        // POST: MemoSignatories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var memoSignatory = await _context.MemoSignatories.FindAsync(id);
            _context.MemoSignatories.Remove(memoSignatory);
            await _context.SaveChangesAsync().ConfigureAwait(false);
            return RedirectToAction(nameof(Index));
        }

        private bool MemoSignatoryExists(int id)
        {
            return _context.MemoSignatories.Any(e => e.IdMemoSignatory == id);
        }
    }
}
