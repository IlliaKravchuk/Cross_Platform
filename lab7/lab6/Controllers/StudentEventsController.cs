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
    public class StudentEventsController : Controller
    {
        private readonly DataContext _context;

        public StudentEventsController(DataContext context)
        {
            _context = context;
        }

        // GET: StudentEvents
        public async Task<IActionResult> Index()
        {
            var dataContext = _context.StudentEvents.Include(s => s.Student);
            return View(await dataContext.ToListAsync());
        }

        // GET: StudentEvents/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentEvent = await _context.StudentEvents
                .Include(s => s.Student)
                .FirstOrDefaultAsync(m => m.StudentEventId == id);
            if (studentEvent == null)
            {
                return NotFound();
            }

            return View(studentEvent);
        }

        // GET: StudentEvents/Create
        public IActionResult Create()
        {
            ViewData["StudentId"] = new SelectList(_context.Students, "StudentId", "StudentId");
            return View();
        }

        // POST: StudentEvents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StudentEventId,StudentId,EventTypeCode,EventDetails")] StudentEvent studentEvent)
        {
            if (ModelState.IsValid)
            {
                _context.Add(studentEvent);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["StudentId"] = new SelectList(_context.Students, "StudentId", "StudentId", studentEvent.StudentId);
            return View(studentEvent);
        }

        // GET: StudentEvents/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentEvent = await _context.StudentEvents.FindAsync(id);
            if (studentEvent == null)
            {
                return NotFound();
            }
            ViewData["StudentId"] = new SelectList(_context.Students, "StudentId", "StudentId", studentEvent.StudentId);
            return View(studentEvent);
        }

        // POST: StudentEvents/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StudentEventId,StudentId,EventTypeCode,EventDetails")] StudentEvent studentEvent)
        {
            if (id != studentEvent.StudentEventId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(studentEvent);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentEventExists(studentEvent.StudentEventId))
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
            ViewData["StudentId"] = new SelectList(_context.Students, "StudentId", "StudentId", studentEvent.StudentId);
            return View(studentEvent);
        }

        // GET: StudentEvents/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentEvent = await _context.StudentEvents
                .Include(s => s.Student)
                .FirstOrDefaultAsync(m => m.StudentEventId == id);
            if (studentEvent == null)
            {
                return NotFound();
            }

            return View(studentEvent);
        }

        // POST: StudentEvents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var studentEvent = await _context.StudentEvents.FindAsync(id);
            if (studentEvent != null)
            {
                _context.StudentEvents.Remove(studentEvent);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentEventExists(int id)
        {
            return _context.StudentEvents.Any(e => e.StudentEventId == id);
        }
    }
}
