using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AspCoreEntityPostgres.DBcontext;
using AspCoreEntityPostgres.Models;
using AspCoreEntityPostgres.ViewModel;
using Microsoft.AspNetCore.Authorization;

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
        public IActionResult Index()
        {
            DolzhIndexViewModel DVM = new DolzhIndexViewModel
            {
                Otdels = new SelectList(_context.Otdels.ToList(), "IdOtdel", "NameOtdel"),
                Dolzhs = _context.Dolzhs.Include(c => c.Otdel)
            };
            return View(DVM);
        }

        // GET: Dolzhs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var dolzh = await _context.Dolzhs.Include(m => m.Otdel).ThenInclude( m => m.LeadOtdel)
                .FirstOrDefaultAsync(m => m.IdDolzh == id).ConfigureAwait(false);
            if (dolzh == null)
            {
                return NotFound();
            }
            return View(dolzh);
        }

        // GET: Dolzhs/Create
        public IActionResult Create()
        {
            DolzhViewModel CVM = new DolzhViewModel
            {
                Otdels = new SelectList(_context.Otdels.ToList(), "IdOtdel", "NameOtdel")
            };
            return View(CVM);
        }

        // POST: Dolzhs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdDolzh,IdOtdel,NameDolzh")] Dolzh dolzh)
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
            DolzhViewModel CVM = new DolzhViewModel
            {
                Dolzh = await _context.Dolzhs.FindAsync(id)
            };
            CVM.Otdels = new SelectList(_context.Otdels.ToList(), "IdOtdel", "NameOtdel", CVM.Dolzh.IdOtdel);
            return View(CVM);
        }

        // POST: Dolzhs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdDolzh,IdOtdel,NameDolzh")] Dolzh dolzh)
        {
            if (dolzh != null)
            {
                if (id != dolzh.IdDolzh)
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
                    if (!DolzhExists(dolzh.IdDolzh))
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
        [Authorize(Roles = "Администратор")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dolzh = await _context.Dolzhs.Include(c => c.Otdel)
                .FirstOrDefaultAsync(m => m.IdDolzh == id).ConfigureAwait(false);
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

        //поиск по названию
        public ActionResult GetDolzhs(string id, int? idotdel)
        {
            DolzhIndexViewModel UVM = new DolzhIndexViewModel();
            if (idotdel != null)
            {
                UVM.Dolzhs = _context.Dolzhs.Include(o => o.Otdel).Where(d => d.IdOtdel == idotdel);
            }
            else
            {
                if (id == null)
                {
                    UVM.Dolzhs = _context.Dolzhs.Include(o => o.Otdel);
                }
                else
                {
                    UVM.Dolzhs = _context.Dolzhs.Include(o => o.Otdel).Where(fio => fio.NameDolzh.Contains(id));
                }
            }

            return PartialView(UVM);
        }
        private bool DolzhExists(int id)
        {
            return _context.Dolzhs.Any(e => e.IdDolzh == id);
        }
    }
}
