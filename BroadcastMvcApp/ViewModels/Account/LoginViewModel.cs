using System.ComponentModel.DataAnnotations;

namespace BroadcastMvcApp.ViewModels.Account;

public class LoginViewModel
{
    [Required]
    [DataType(DataType.EmailAddress)]
    public string? Email { get; set; } = string.Empty;

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; } = string.Empty;

    public string? ErrorMessages { get; set; }
}
