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
    public class StudentLoansController : Controller
    {
        private readonly DataContext _context;

        public StudentLoansController(DataContext context)
        {
            _context = context;
        }

        // GET: StudentLoans
        public async Task<IActionResult> Index()
        {
            var dataContext = _context.StudentLoans.Include(s => s.Student);
            return View(await dataContext.ToListAsync());
        }

        // GET: StudentLoans/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentLoan = await _context.StudentLoans
                .Include(s => s.Student)
                .FirstOrDefaultAsync(m => m.StudentLoanId == id);
            if (studentLoan == null)
            {
                return NotFound();
            }

            return View(studentLoan);
        }

        // GET: StudentLoans/Create
        public IActionResult Create()
        {
            ViewData["StudentId"] = new SelectList(_context.Students, "StudentId", "StudentId");
            return View();
        }

        // POST: StudentLoans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StudentLoanId,StudentId,DateOfLoan,AmountOfLoan,LoanDetails")] StudentLoan studentLoan)
        {
            if (ModelState.IsValid)
            {
                _context.Add(studentLoan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["StudentId"] = new SelectList(_context.Students, "StudentId", "StudentId", studentLoan.StudentId);
            return View(studentLoan);
        }

        // GET: StudentLoans/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentLoan = await _context.StudentLoans.FindAsync(id);
            if (studentLoan == null)
            {
                return NotFound();
            }
            ViewData["StudentId"] = new SelectList(_context.Students, "StudentId", "StudentId", studentLoan.StudentId);
            return View(studentLoan);
        }

        // POST: StudentLoans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StudentLoanId,StudentId,DateOfLoan,AmountOfLoan,LoanDetails")] StudentLoan studentLoan)
        {
            if (id != studentLoan.StudentLoanId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(studentLoan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentLoanExists(studentLoan.StudentLoanId))
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
            ViewData["StudentId"] = new SelectList(_context.Students, "StudentId", "StudentId", studentLoan.StudentId);
            return View(studentLoan);
        }

        // GET: StudentLoans/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentLoan = await _context.StudentLoans
                .Include(s => s.Student)
                .FirstOrDefaultAsync(m => m.StudentLoanId == id);
            if (studentLoan == null)
            {
                return NotFound();
            }

            return View(studentLoan);
        }

        // POST: StudentLoans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var studentLoan = await _context.StudentLoans.FindAsync(id);
            if (studentLoan != null)
            {
                _context.StudentLoans.Remove(studentLoan);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentLoanExists(int id)
        {
            return _context.StudentLoans.Any(e => e.StudentLoanId == id);
        }
    }
}
