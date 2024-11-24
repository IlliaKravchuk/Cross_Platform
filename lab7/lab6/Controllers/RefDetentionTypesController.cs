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
    public class RefDetentionTypesController : Controller
    {
        private readonly DataContext _context;

        public RefDetentionTypesController(DataContext context)
        {
            _context = context;
        }

        // GET: RefDetentionTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.RefDetentionTypes.ToListAsync());
        }

        // GET: RefDetentionTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var refDetentionType = await _context.RefDetentionTypes
                .FirstOrDefaultAsync(m => m.DetentionTypeCode == id);
            if (refDetentionType == null)
            {
                return NotFound();
            }

            return View(refDetentionType);
        }

        // GET: RefDetentionTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RefDetentionTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DetentionTypeCode,DetentionTypeDescription")] RefDetentionType refDetentionType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(refDetentionType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(refDetentionType);
        }

        // GET: RefDetentionTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var refDetentionType = await _context.RefDetentionTypes.FindAsync(id);
            if (refDetentionType == null)
            {
                return NotFound();
            }
            return View(refDetentionType);
        }

        // POST: RefDetentionTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DetentionTypeCode,DetentionTypeDescription")] RefDetentionType refDetentionType)
        {
            if (id != refDetentionType.DetentionTypeCode)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(refDetentionType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RefDetentionTypeExists(refDetentionType.DetentionTypeCode))
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
            return View(refDetentionType);
        }

        // GET: RefDetentionTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var refDetentionType = await _context.RefDetentionTypes
                .FirstOrDefaultAsync(m => m.DetentionTypeCode == id);
            if (refDetentionType == null)
            {
                return NotFound();
            }

            return View(refDetentionType);
        }

        // POST: RefDetentionTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var refDetentionType = await _context.RefDetentionTypes.FindAsync(id);
            if (refDetentionType != null)
            {
                _context.RefDetentionTypes.Remove(refDetentionType);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RefDetentionTypeExists(int id)
        {
            return _context.RefDetentionTypes.Any(e => e.DetentionTypeCode == id);
        }
    }
}
