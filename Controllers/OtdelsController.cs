﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AspCoreEntityPostgres.DBcontext;
using AspCoreEntityPostgres.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AspCoreEntityPostgres.Controllers
{
    public class OtdelsController : Controller
    {
        private readonly ApplicationContext _context;

        public OtdelsController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: Otdels
        public async Task<IActionResult> Index()
        {
            return View(await _context.Otdels.Include(m => m.LeadOtdel).ToListAsync().ConfigureAwait(false));
        }

        // GET: Otdels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var otdel = await _context.Otdels.Include(m => m.LeadOtdel)
                .FirstOrDefaultAsync(m => m.IdOtdel == id).ConfigureAwait(false);
            if (otdel == null)
            {
                return NotFound();
            }

            return View(otdel);
        }

        // GET: Otdels/Create
        public IActionResult Create()
        {
            ViewData["IdUser"] = new SelectList(_context.Users, "IdUser", "UserFIO");
            return View();
        }

        // POST: Otdels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id_Otdel,NameOtdel,IdLeadOtdel")] Otdel otdel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(otdel);
                await _context.SaveChangesAsync().ConfigureAwait(false);
                return RedirectToAction(nameof(Index));
            }
            return View(otdel);
        }

        // GET: Otdels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var otdel = await _context.Otdels.FindAsync(id);
            ViewData["IdLeadOtdel"] = new SelectList(_context.Users, "IdUser", "UserFIO", otdel.IdLeadOtdel);

            if (otdel == null)
            {
                return NotFound();
            }
            return View(otdel);
        }

        // POST: Otdels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdOtdel,NameOtdel,IdLeadOtdel")] Otdel otdel)
        {
            if (id != otdel.IdOtdel)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(otdel);
                    await _context.SaveChangesAsync().ConfigureAwait(false);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OtdelExists(otdel.IdOtdel))
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
            return View(otdel);
        }

        // GET: Otdels/Delete/5
        [Authorize(Roles = "Администратор")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var otdel = await _context.Otdels
                .FirstOrDefaultAsync(m => m.IdOtdel == id).ConfigureAwait(false);
            if (otdel == null)
            {
                return NotFound();
            }

            return View(otdel);
        }

        // POST: Otdels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var otdel = await _context.Otdels.FindAsync(id);
            _context.Otdels.Remove(otdel);
            await _context.SaveChangesAsync().ConfigureAwait(false);
            return RedirectToAction(nameof(Index));
        }

        //поиск по фио
        public ActionResult GetOtdels(string id)
        {
            if(id == null)
            {
                return PartialView(_context.Otdels.Include(m => m.LeadOtdel));
            }
            return PartialView(_context.Otdels.Include(m => m.LeadOtdel).Where(c => c.NameOtdel.Contains(id)));
        }

        private bool OtdelExists(int id)
        {
            return _context.Otdels.Any(e => e.IdOtdel == id);
        }
    }
}
