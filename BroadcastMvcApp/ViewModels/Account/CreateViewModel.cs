using BroadcastMvcApp.Enum;
using System.ComponentModel.DataAnnotations;

namespace BroadcastMvcApp.ViewModels.Account;

public class CreateViewModel
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;

    [DataType(DataType.EmailAddress)]
    public string Email { get; set; } = string.Empty;

    [DataType(DataType.Password)]
    public string Password { get; set; } = string.Empty;

    [DataType(DataType.Password)]
    [Compare(nameof(Password), ErrorMessage = "Passwords do not match!")]
    public string ConfirmPassword { get; set; } = string.Empty;

    public string? Authorization { get; set; }

    public IFormFile? Profile { get; set; }

    public Roles Role { get; set; }
    public Departments? Department { get; set; }
    public Semesters? Semester { get; set; }
}
