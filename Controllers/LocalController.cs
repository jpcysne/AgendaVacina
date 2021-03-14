using AgendaVacina.Data;
using AgendaVacina.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgendaVacina.Controllers
{
    public class LocalController : Controller
    {
        private readonly AgendaVacinaContext _context;

        public LocalController(AgendaVacinaContext context)
        {
            _context = context;
        }

        // GET: Local
        public async Task<IActionResult> Index()
        {
            return View(await _context.Local.ToListAsync());
        }

        // GET: Local/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var local = await _context.Local
                .FirstOrDefaultAsync(m => m.Id == id);
            if (local == null)
            {
                return NotFound();
            }

            return View(local);
        }

        // GET: Local/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Local/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Endereco")] Local local)
        {
            if (ModelState.IsValid)
            {
                _context.Add(local);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(local);
        }

        // GET: Local/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var local = await _context.Local.FindAsync(id);
            if (local == null)
            {
                return NotFound();
            }
            return View(local);
        }

        // POST: Local/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Endereco")] Local local)
        {
            if (id != local.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(local);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LocalExists(local.Id))
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
            return View(local);
        }

        // GET: Local/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var local = await _context.Local
                .FirstOrDefaultAsync(m => m.Id == id);
            if (local == null)
            {
                return NotFound();
            }

            return View(local);
        }

        // POST: Local/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var local = await _context.Local.FindAsync(id);
            _context.Local.Remove(local);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LocalExists(int id)
        {
            return _context.Local.Any(e => e.Id == id);
        }
    }
}
