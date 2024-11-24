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
    public class RefEventTypesController : Controller
    {
        private readonly DataContext _context;

        public RefEventTypesController(DataContext context)
        {
            _context = context;
        }

        // GET: RefEventTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.RefEventTypes.ToListAsync());
        }

        // GET: RefEventTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var refEventType = await _context.RefEventTypes
                .FirstOrDefaultAsync(m => m.EventTypeCode == id);
            if (refEventType == null)
            {
                return NotFound();
            }

            return View(refEventType);
        }

        // GET: RefEventTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RefEventTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EventTypeCode,EventTypeDescription")] RefEventType refEventType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(refEventType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(refEventType);
        }

        // GET: RefEventTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var refEventType = await _context.RefEventTypes.FindAsync(id);
            if (refEventType == null)
            {
                return NotFound();
            }
            return View(refEventType);
        }

        // POST: RefEventTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EventTypeCode,EventTypeDescription")] RefEventType refEventType)
        {
            if (id != refEventType.EventTypeCode)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(refEventType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RefEventTypeExists(refEventType.EventTypeCode))
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
            return View(refEventType);
        }

        // GET: RefEventTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var refEventType = await _context.RefEventTypes
                .FirstOrDefaultAsync(m => m.EventTypeCode == id);
            if (refEventType == null)
            {
                return NotFound();
            }

            return View(refEventType);
        }

        // POST: RefEventTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var refEventType = await _context.RefEventTypes.FindAsync(id);
            if (refEventType != null)
            {
                _context.RefEventTypes.Remove(refEventType);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RefEventTypeExists(int id)
        {
            return _context.RefEventTypes.Any(e => e.EventTypeCode == id);
        }
    }
}
