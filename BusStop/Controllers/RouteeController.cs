using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BusStop.Data;
using BusStop.Models;

namespace BusStop.Controllers
{
    public class RouteeController : Controller
    {
        private readonly BusStopContext _context;

        public RouteeController(BusStopContext context)
        {
            _context = context;
        }

        // GET: Routee
        public async Task<IActionResult> Index()
        {
              return _context.Routee != null ? 
                          View(await _context.Routee.ToListAsync()) :
                          Problem("Entity set 'BusStopContext.Routee'  is null.");
        }

        // GET: Routee/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Routee == null)
            {
                return NotFound();
            }

            var routee = await _context.Routee
                .FirstOrDefaultAsync(m => m.RouteId == id);
            if (routee == null)
            {
                return NotFound();
            }

            return View(routee);
        }

        // GET: Routee/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Routee/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RouteId,Stop1,Stop2,Stop3")] Routee routee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(routee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(routee);
        }

        // GET: Routee/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Routee == null)
            {
                return NotFound();
            }

            var routee = await _context.Routee.FindAsync(id);
            if (routee == null)
            {
                return NotFound();
            }
            return View(routee);
        }

        // POST: Routee/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RouteId,Stop1,Stop2,Stop3")] Routee routee)
        {
            if (id != routee.RouteId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(routee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RouteeExists(routee.RouteId))
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
            return View(routee);
        }

        // GET: Routee/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Routee == null)
            {
                return NotFound();
            }

            var routee = await _context.Routee
                .FirstOrDefaultAsync(m => m.RouteId == id);
            if (routee == null)
            {
                return NotFound();
            }

            return View(routee);
        }

        // POST: Routee/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Routee == null)
            {
                return Problem("Entity set 'BusStopContext.Routee'  is null.");
            }
            var routee = await _context.Routee.FindAsync(id);
            if (routee != null)
            {
                _context.Routee.Remove(routee);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RouteeExists(int id)
        {
          return (_context.Routee?.Any(e => e.RouteId == id)).GetValueOrDefault();
        }
    }
}
