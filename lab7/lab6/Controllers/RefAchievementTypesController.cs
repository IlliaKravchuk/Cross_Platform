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
    public class RefAchievementTypesController : Controller
    {
        private readonly DataContext _context;

        public RefAchievementTypesController(DataContext context)
        {
            _context = context;
        }

        // GET: RefAchievementTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.RefAchievementTypes.ToListAsync());
        }

        // GET: RefAchievementTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var refAchievementType = await _context.RefAchievementTypes
                .FirstOrDefaultAsync(m => m.AchievementTypeCode == id);
            if (refAchievementType == null)
            {
                return NotFound();
            }

            return View(refAchievementType);
        }

        // GET: RefAchievementTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RefAchievementTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AchievementTypeCode,AchievementTypeDescription")] RefAchievementType refAchievementType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(refAchievementType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(refAchievementType);
        }

        // GET: RefAchievementTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var refAchievementType = await _context.RefAchievementTypes.FindAsync(id);
            if (refAchievementType == null)
            {
                return NotFound();
            }
            return View(refAchievementType);
        }

        // POST: RefAchievementTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AchievementTypeCode,AchievementTypeDescription")] RefAchievementType refAchievementType)
        {
            if (id != refAchievementType.AchievementTypeCode)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(refAchievementType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RefAchievementTypeExists(refAchievementType.AchievementTypeCode))
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
            return View(refAchievementType);
        }

        // GET: RefAchievementTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var refAchievementType = await _context.RefAchievementTypes
                .FirstOrDefaultAsync(m => m.AchievementTypeCode == id);
            if (refAchievementType == null)
            {
                return NotFound();
            }

            return View(refAchievementType);
        }

        // POST: RefAchievementTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var refAchievementType = await _context.RefAchievementTypes.FindAsync(id);
            if (refAchievementType != null)
            {
                _context.RefAchievementTypes.Remove(refAchievementType);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RefAchievementTypeExists(int id)
        {
            return _context.RefAchievementTypes.Any(e => e.AchievementTypeCode == id);
        }
    }
}
