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
    public class DolzhsController : Controller
    {
        private readonly ApplicationContext _context;

        public DolzhsController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: Dolzhs
        public async Task<IActionResult> Index()
        {
            return View(await _context.Dolzhs.ToListAsync().ConfigureAwait(false));
        }

        // GET: Dolzhs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dolzh = await _context.Dolzhs
                .FirstOrDefaultAsync(m => m.Id_Dolzh == id).ConfigureAwait(false);
            if (dolzh == null)
            {
                return NotFound();
            }
            _context.Entry(dolzh).Reference(c => c.Otdel).Load();

            return View(dolzh);
        }

        // GET: Dolzhs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Dolzhs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id_Dolzh,Id_Otdel,NameDolzh")] Dolzh dolzh)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dolzh);
                await _context.SaveChangesAsync().ConfigureAwait(false);
                return RedirectToAction(nameof(Index));
            }
            return View(dolzh);
        }

        // GET: Dolzhs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dolzh = await _context.Dolzhs.FindAsync(id);
            if (dolzh == null)
            {
                return NotFound();
            }
            return View(dolzh);
        }

        // POST: Dolzhs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id_Dolzh,Id_Otdel,NameDolzh")] Dolzh dolzh)
        {
            if (dolzh != null)
            {
                if (id != dolzh.Id_Dolzh)
                {
                    return NotFound();
                }
            

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dolzh);
                    await _context.SaveChangesAsync().ConfigureAwait(false);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DolzhExists(dolzh.Id_Dolzh))
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
            return View(dolzh);
            }
            return null;
        }

        // GET: Dolzhs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dolzh = await _context.Dolzhs
                .FirstOrDefaultAsync(m => m.Id_Dolzh == id).ConfigureAwait(false);
            if (dolzh == null)
            {
                return NotFound();
            }

            return View(dolzh);
        }

        // POST: Dolzhs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dolzh = await _context.Dolzhs.FindAsync(id);
            _context.Dolzhs.Remove(dolzh);
            await _context.SaveChangesAsync().ConfigureAwait(false);
            return RedirectToAction(nameof(Index));
        }

        private bool DolzhExists(int id)
        {
            return _context.Dolzhs.Any(e => e.Id_Dolzh == id);
        }
    }
}
