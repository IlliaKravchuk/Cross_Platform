using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

public class RegisterModel : PageModel
{
    [BindProperty]
    [Required(ErrorMessage = "��'� ����������� � ����'�������.")]
    [StringLength(50, ErrorMessage = "��'� ����������� �� ���� ������������ 50 �������.")]
    public string Username { get; set; }

    [BindProperty]
    [Required(ErrorMessage = "Բ� � ����'�������.")]
    [StringLength(500, ErrorMessage = "Բ� �� ���� ������������ 500 �������.")]
    public string FullName { get; set; }

    [BindProperty]
    [Required(ErrorMessage = "������ � ����'�������.")]
    [StringLength(16, MinimumLength = 8, ErrorMessage = "������ �� ���� �� 8 �� 16 �������.")]
    [RegularExpression(@"^(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,16}$",
        ErrorMessage = "������ ������� ������ ���� � ���� ������ �����, ����� �� ����������� ������.")]
    public string Password { get; set; }

    [BindProperty]
    [Required(ErrorMessage = "ϳ����������� ������ � ����'�������.")]
    [Compare("Password", ErrorMessage = "����� �� ����������.")]
    public string ConfirmPassword { get; set; }

    [BindProperty]
    [Required(ErrorMessage = "������� � ����'�������.")]
    [RegularExpression(@"^\+380\d{9}$", ErrorMessage = "������� �� ���� � ������ +380XXXXXXXXX.")]
    public string Phone { get; set; }

    [BindProperty]
    [Required(ErrorMessage = "���������� ������ � ����'�������.")]
    [EmailAddress(ErrorMessage = "������� ������ ���������� ������.")]
    public string Email { get; set; }

    public IActionResult OnPost()
    {
        if (ModelState.IsValid)
        {
            // ��� ����� �������� ��� ����������� ��� �������� ���� �����
            TempData["SuccessMessage"] = "��������� ������!";
            return RedirectToPage("/Index");
        }

        return Page();
    }
}