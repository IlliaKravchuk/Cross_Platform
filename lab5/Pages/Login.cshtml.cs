using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;

public class LoginModel : PageModel
{
    [BindProperty]
    public string Username { get; set; }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!string.IsNullOrEmpty(Username))
        {

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, Username)
            };

            var identity = new ClaimsIdentity(claims, "Cookies");
            var principal = new ClaimsPrincipal(identity);


            await HttpContext.SignInAsync("Cookies", principal);

            return RedirectToPage("/Index");
        }

        return Page();
    }
}