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
    public class RefAddressTypesController : Controller
    {
        private readonly DataContext _context;

        public RefAddressTypesController(DataContext context)
        {
            _context = context;
        }

        // GET: RefAddressTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.RefAddressTypes.ToListAsync());
        }

        // GET: RefAddressTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var refAddressType = await _context.RefAddressTypes
                .FirstOrDefaultAsync(m => m.AddressTypeId == id);
            if (refAddressType == null)
            {
                return NotFound();
            }

            return View(refAddressType);
        }

        // GET: RefAddressTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RefAddressTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AddressTypeId,AddressTypeDescription")] RefAddressType refAddressType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(refAddressType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(refAddressType);
        }

        // GET: RefAddressTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var refAddressType = await _context.RefAddressTypes.FindAsync(id);
            if (refAddressType == null)
            {
                return NotFound();
            }
            return View(refAddressType);
        }

        // POST: RefAddressTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AddressTypeId,AddressTypeDescription")] RefAddressType refAddressType)
        {
            if (id != refAddressType.AddressTypeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(refAddressType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RefAddressTypeExists(refAddressType.AddressTypeId))
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
            return View(refAddressType);
        }

        // GET: RefAddressTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var refAddressType = await _context.RefAddressTypes
                .FirstOrDefaultAsync(m => m.AddressTypeId == id);
            if (refAddressType == null)
            {
                return NotFound();
            }

            return View(refAddressType);
        }

        // POST: RefAddressTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var refAddressType = await _context.RefAddressTypes.FindAsync(id);
            if (refAddressType != null)
            {
                _context.RefAddressTypes.Remove(refAddressType);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RefAddressTypeExists(int id)
        {
            return _context.RefAddressTypes.Any(e => e.AddressTypeId == id);
        }
    }
}
