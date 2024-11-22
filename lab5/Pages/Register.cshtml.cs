using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

public class RegisterModel : PageModel
{
    [BindProperty]
    [Required(ErrorMessage = "Ім'я користувача є обов'язковим.")]
    [StringLength(50, ErrorMessage = "Ім'я користувача не може перевищувати 50 символів.")]
    public string Username { get; set; }

    [BindProperty]
    [Required(ErrorMessage = "ФІО є обов'язковим.")]
    [StringLength(500, ErrorMessage = "ФІО не може перевищувати 500 символів.")]
    public string FullName { get; set; }

    [BindProperty]
    [Required(ErrorMessage = "Пароль є обов'язковим.")]
    [StringLength(16, MinimumLength = 8, ErrorMessage = "Пароль має бути від 8 до 16 символів.")]
    [RegularExpression(@"^(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,16}$",
        ErrorMessage = "Пароль повинен містити хоча б одну велику літеру, цифру та спеціальний символ.")]
    public string Password { get; set; }

    [BindProperty]
    [Required(ErrorMessage = "Підтвердження паролю є обов'язковим.")]
    [Compare("Password", ErrorMessage = "Паролі не співпадають.")]
    public string ConfirmPassword { get; set; }

    [BindProperty]
    [Required(ErrorMessage = "Телефон є обов'язковим.")]
    [RegularExpression(@"^\+380\d{9}$", ErrorMessage = "Телефон має бути у форматі +380XXXXXXXXX.")]
    public string Phone { get; set; }

    [BindProperty]
    [Required(ErrorMessage = "Електронна адреса є обов'язковою.")]
    [EmailAddress(ErrorMessage = "Невірний формат електронної адреси.")]
    public string Email { get; set; }

    public IActionResult OnPost()
    {
        if (ModelState.IsValid)
        {
            // Тут можна зберігати дані користувача або виконати іншу логіку
            TempData["SuccessMessage"] = "Реєстрація успішна!";
            return RedirectToPage("/Index");
        }

        return Page();
    }
}