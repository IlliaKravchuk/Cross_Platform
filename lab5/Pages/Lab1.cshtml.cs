using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication1.Pages
{
    [Authorize]
    public class Lab1Model : PageModel
    {
        public void OnGet()
        {
        }
    }
}
