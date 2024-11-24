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
    public class StudentAddressesController : Controller
    {
        private readonly DataContext _context;

        public StudentAddressesController(DataContext context)
        {
            _context = context;
        }

        // GET: StudentAddresses
        public async Task<IActionResult> Index()
        {
            var dataContext = _context.StudentAddresses.Include(s => s.Address).Include(s => s.Student);
            return View(await dataContext.ToListAsync());
        }

        // GET: StudentAddresses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentAddress = await _context.StudentAddresses
                .Include(s => s.Address)
                .Include(s => s.Student)
                .FirstOrDefaultAsync(m => m.StudentAddressId == id);
            if (studentAddress == null)
            {
                return NotFound();
            }

            return View(studentAddress);
        }

        // GET: StudentAddresses/Create
        public IActionResult Create()
        {
            ViewData["AddressId"] = new SelectList(_context.Addresses, "AddressId", "AddressId");
            ViewData["StudentId"] = new SelectList(_context.Students, "StudentId", "StudentId");
            return View();
        }

        // POST: StudentAddresses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StudentAddressId,StudentId,AddressId,AddressTypeId,DateFrom,DateTo")] StudentAddress studentAddress)
        {
            if (ModelState.IsValid)
            {
                _context.Add(studentAddress);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AddressId"] = new SelectList(_context.Addresses, "AddressId", "AddressId", studentAddress.AddressId);
            ViewData["StudentId"] = new SelectList(_context.Students, "StudentId", "StudentId", studentAddress.StudentId);
            return View(studentAddress);
        }

        // GET: StudentAddresses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentAddress = await _context.StudentAddresses.FindAsync(id);
            if (studentAddress == null)
            {
                return NotFound();
            }
            ViewData["AddressId"] = new SelectList(_context.Addresses, "AddressId", "AddressId", studentAddress.AddressId);
            ViewData["StudentId"] = new SelectList(_context.Students, "StudentId", "StudentId", studentAddress.StudentId);
            return View(studentAddress);
        }

        // POST: StudentAddresses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StudentAddressId,StudentId,AddressId,AddressTypeId,DateFrom,DateTo")] StudentAddress studentAddress)
        {
            if (id != studentAddress.StudentAddressId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(studentAddress);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentAddressExists(studentAddress.StudentAddressId))
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
            ViewData["AddressId"] = new SelectList(_context.Addresses, "AddressId", "AddressId", studentAddress.AddressId);
            ViewData["StudentId"] = new SelectList(_context.Students, "StudentId", "StudentId", studentAddress.StudentId);
            return View(studentAddress);
        }

        // GET: StudentAddresses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentAddress = await _context.StudentAddresses
                .Include(s => s.Address)
                .Include(s => s.Student)
                .FirstOrDefaultAsync(m => m.StudentAddressId == id);
            if (studentAddress == null)
            {
                return NotFound();
            }

            return View(studentAddress);
        }

        // POST: StudentAddresses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var studentAddress = await _context.StudentAddresses.FindAsync(id);
            if (studentAddress != null)
            {
                _context.StudentAddresses.Remove(studentAddress);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentAddressExists(int id)
        {
            return _context.StudentAddresses.Any(e => e.StudentAddressId == id);
        }
    }
}
