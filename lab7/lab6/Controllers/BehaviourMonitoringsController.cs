using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Lab6.Data;
using Lab6.Models;

namespace lab6.Controllers
{
    public class BehaviourMonitoringsController : Controller
    {
        private readonly DataContext _context;

        public BehaviourMonitoringsController(DataContext context)
        {
            _context = context;
        }

        // GET: BehaviourMonitorings
        public async Task<IActionResult> Index()
        {
            var dataContext = _context.BehaviourMonitorings.Include(b => b.Student);
            return View(await dataContext.ToListAsync());
        }

        // GET: BehaviourMonitorings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var behaviourMonitoring = await _context.BehaviourMonitorings
                .Include(b => b.Student)
                .FirstOrDefaultAsync(m => m.BehaviourMonitoringId == id);
            if (behaviourMonitoring == null)
            {
                return NotFound();
            }

            return View(behaviourMonitoring);
        }

        // GET: BehaviourMonitorings/Create
        public IActionResult Create()
        {
            ViewData["StudentId"] = new SelectList(_context.Students, "StudentId", "StudentId");
            return View();
        }

        // POST: BehaviourMonitorings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BehaviourMonitoringId,StudentId,MonitoringDetails")] BehaviourMonitoring behaviourMonitoring)
        {
            if (ModelState.IsValid)
            {
                _context.Add(behaviourMonitoring);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["StudentId"] = new SelectList(_context.Students, "StudentId", "StudentId", behaviourMonitoring.StudentId);
            return View(behaviourMonitoring);
        }

        // GET: BehaviourMonitorings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var behaviourMonitoring = await _context.BehaviourMonitorings.FindAsync(id);
            if (behaviourMonitoring == null)
            {
                return NotFound();
            }
            ViewData["StudentId"] = new SelectList(_context.Students, "StudentId", "StudentId", behaviourMonitoring.StudentId);
            return View(behaviourMonitoring);
        }

        // POST: BehaviourMonitorings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BehaviourMonitoringId,StudentId,MonitoringDetails")] BehaviourMonitoring behaviourMonitoring)
        {
            if (id != behaviourMonitoring.BehaviourMonitoringId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(behaviourMonitoring);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BehaviourMonitoringExists(behaviourMonitoring.BehaviourMonitoringId))
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
            ViewData["StudentId"] = new SelectList(_context.Students, "StudentId", "StudentId", behaviourMonitoring.StudentId);
            return View(behaviourMonitoring);
        }

        // GET: BehaviourMonitorings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var behaviourMonitoring = await _context.BehaviourMonitorings
                .Include(b => b.Student)
                .FirstOrDefaultAsync(m => m.BehaviourMonitoringId == id);
            if (behaviourMonitoring == null)
            {
                return NotFound();
            }

            return View(behaviourMonitoring);
        }

        // POST: BehaviourMonitorings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var behaviourMonitoring = await _context.BehaviourMonitorings.FindAsync(id);
            if (behaviourMonitoring != null)
            {
                _context.BehaviourMonitorings.Remove(behaviourMonitoring);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BehaviourMonitoringExists(int id)
        {
            return _context.BehaviourMonitorings.Any(e => e.BehaviourMonitoringId == id);
        }
    }
}
