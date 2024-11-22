using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Lab6.Data;
using Lab6.Models;

namespace Lab6.Pages.Students
{
    public class SearchModel : PageModel
    {
        private readonly DataContext _context;

        public SearchModel(DataContext context)
        {
            _context = context;
        }

        public IList<Student> Students { get; set; }

        public async Task OnGetAsync(string searchString, DateTime? searchDate)
        {
            var students = from s in _context.Students
                select s;

            if (!string.IsNullOrEmpty(searchString))
            {
                students = students.Where(s => s.BioData.Contains(searchString) || s.StudentDetails.Contains(searchString));
            }

            if (searchDate.HasValue)
            {
                students = students.Where(s => s.CreatedDate.Date == searchDate.Value.Date);
            }

            Students = await students.ToListAsync();
        }
    }
}