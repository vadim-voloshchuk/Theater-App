using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyMVCapp.Data;
using MyMVCapp.Models;

namespace MyMVCapp.Controllers
{
    public class SpectacleController : Controller
    {
        private readonly MyMVCappContext _context;

        public SpectacleController(MyMVCappContext context)
        {
            _context = context;
        }

        // GET: Spectacle
        public async Task<IActionResult> Index()
        {
              return _context.Spectacle != null ? 
                          View(await _context.Spectacle.ToListAsync()) :
                          Problem("Entity set 'MyMVCappContext.Spectacle'  is null.");
        }

        // GET: Spectacle/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Spectacle == null)
            {
                return NotFound();
            }

            var spectacle = await _context.Spectacle
                .FirstOrDefaultAsync(m => m.SpectacleID == id);
            if (spectacle == null)
            {
                return NotFound();
            }
            ViewBag.var1 = await _context.Spectacle.ToListAsync();

            return View(spectacle);
        }

        // GET: Spectacle/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Spectacle/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SpectacleID,Title,Director,Genre,Description,StartDate,EndDate,Price")] Spectacle spectacle)
        {
            if (ModelState.IsValid)
            {
                _context.Add(spectacle);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(spectacle);
        }

        // GET: Spectacle/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Spectacle == null)
            {
                return NotFound();
            }

            var spectacle = await _context.Spectacle.FindAsync(id);
            if (spectacle == null)
            {
                return NotFound();
            }
            return View(spectacle);
        }

        // POST: Spectacle/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SpectacleID,Title,Director,Genre,Description,StartDate,EndDate,Price")] Spectacle spectacle)
        {
            if (id != spectacle.SpectacleID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(spectacle);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SpectacleExists(spectacle.SpectacleID))
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
            return View(spectacle);
        }

        // GET: Spectacle/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Spectacle == null)
            {
                return NotFound();
            }

            var spectacle = await _context.Spectacle
                .FirstOrDefaultAsync(m => m.SpectacleID == id);
            if (spectacle == null)
            {
                return NotFound();
            }

            return View(spectacle);
        }

        // POST: Spectacle/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Spectacle == null)
            {
                return Problem("Entity set 'MyMVCappContext.Spectacle'  is null.");
            }
            var spectacle = await _context.Spectacle.FindAsync(id);
            if (spectacle != null)
            {
                _context.Spectacle.Remove(spectacle);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SpectacleExists(int id)
        {
          return (_context.Spectacle?.Any(e => e.SpectacleID == id)).GetValueOrDefault();
        }
    }
}
