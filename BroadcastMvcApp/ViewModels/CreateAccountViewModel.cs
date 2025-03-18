using BroadcastMvcApp.Enum;
using System.ComponentModel.DataAnnotations;
using BroadcastMvcApp.Attributes;

namespace BroadcastMvcApp.ViewModels;

public class CreateAccountViewModel
{
    [Required]
    public string Name { get; set; }

    [UniqueEmail]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    [Required]
    [DataType(DataType.Password)]
    [Compare("Password", ErrorMessage = "passwords do not match!")]
    public string ConfirmPassword { get; set; }

    [Required]
    public string Authorization { get; set; }

    public IFormFile ProfilePhoto { get; set; }

    public Roles roles { get; set; }
    public Departments? departments { get; set; }
    public Semesters? semesters { get; set; }
}
