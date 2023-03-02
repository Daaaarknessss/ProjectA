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
    public class AllocateController : Controller
    {
        private readonly BusStopContext _context;

        public AllocateController(BusStopContext context)
        {
            _context = context;
        }

        // GET: Allocate
        public async Task<IActionResult> Index()
        {
            var busStopContext = _context.Allocate.Include(a => a.Employee).Include(a => a.Routee).Include(a => a.Vehicle);
            return View(await busStopContext.ToListAsync());
        }

        // GET: Allocate/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Allocate == null)
            {
                return NotFound();
            }

            var allocate = await _context.Allocate
                .Include(a => a.Employee)
                .Include(a => a.Routee)
                .Include(a => a.Vehicle)
                .FirstOrDefaultAsync(m => m.allocateID == id);
            if (allocate == null)
            {
                return NotFound();
            }

            return View(allocate);
        }

        // GET: Allocate/Create
        public IActionResult Create()
        {
            ViewData["EmployeeID"] = new SelectList(_context.Employee, "EmployeeId", "EmployeeId");
            ViewData["RouteeID"] = new SelectList(_context.Routee, "RouteId", "RouteId");
            ViewData["VehicleID"] = new SelectList(_context.Vehicle, "VehicleId", "VehicleId");
            return View();
        }

        // POST: Allocate/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("allocateID,EmployeeID,VehicleID,RouteeID")] Allocate allocate)
        {
            var a = allocate.VehicleID;
            if (ModelState.IsValid)
            {
                _context.Add(allocate);
                await _context.SaveChangesAsync();
                await UpdateSeat(a);
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmployeeID"] = new SelectList(_context.Employee, "EmployeeId", "EmployeeId", allocate.EmployeeID);
            ViewData["RouteeID"] = new SelectList(_context.Routee, "RouteId", "RouteId", allocate.RouteeID);
            ViewData["VehicleID"] = new SelectList(_context.Vehicle, "VehicleId", "VehicleId", allocate.VehicleID);
            return View(allocate);
        }

        // GET: Allocate/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Allocate == null)
            {
                return NotFound();
            }

            var allocate = await _context.Allocate.FindAsync(id);
            if (allocate == null)
            {
                return NotFound();
            }
            ViewData["EmployeeID"] = new SelectList(_context.Employee, "EmployeeId", "EmployeeId", allocate.EmployeeID);
            ViewData["RouteeID"] = new SelectList(_context.Routee, "RouteId", "RouteId", allocate.RouteeID);
            ViewData["VehicleID"] = new SelectList(_context.Vehicle, "VehicleId", "VehicleId", allocate.VehicleID);
            return View(allocate);
        }

        // POST: Allocate/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("allocateID,EmployeeID,VehicleID,RouteeID")] Allocate allocate)
        {
            if (id != allocate.allocateID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(allocate);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AllocateExists(allocate.allocateID))
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
            ViewData["EmployeeID"] = new SelectList(_context.Employee, "EmployeeId", "EmployeeId", allocate.EmployeeID);
            ViewData["RouteeID"] = new SelectList(_context.Routee, "RouteId", "RouteId", allocate.RouteeID);
            ViewData["VehicleID"] = new SelectList(_context.Vehicle, "VehicleId", "VehicleId", allocate.VehicleID);
            return View(allocate);
        }

        // GET: Allocate/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Allocate == null)
            {
                return NotFound();
            }

            var allocate = await _context.Allocate
                .Include(a => a.Employee)
                .Include(a => a.Routee)
                .Include(a => a.Vehicle)
                .FirstOrDefaultAsync(m => m.allocateID == id);
            if (allocate == null)
            {
                return NotFound();
            }

            return View(allocate);
        }

        // POST: Allocate/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Allocate == null)
            {
                return Problem("Entity set 'BusStopContext.Allocate'  is null.");
            }
            var allocate = await _context.Allocate.FindAsync(id);
            if (allocate != null)
            {
                _context.Allocate.Remove(allocate);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AllocateExists(int id)
        {
          return (_context.Allocate?.Any(e => e.allocateID == id)).GetValueOrDefault();
        }
        public async Task<IActionResult> UpdateSeat(string a)
        {
            var allocate = _context.Allocate;
            using(var dbconnect = _context)
            {
                Vehicle? l = dbconnect.Vehicle.Find(a);
                int b = l.AvailableSeats;
                l.AvailableSeats = b - 1;
                dbconnect.SaveChangesAsync();
                return View(allocate);
            }
        }
    }
}
