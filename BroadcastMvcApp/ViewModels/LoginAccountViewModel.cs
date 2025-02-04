using System;
using System.ComponentModel.DataAnnotations;
using BroadcastMvcApp.Models;

namespace BroadcastMvcApp.ViewModels;

public class LoginAccountViewModel
{
    [Required]
    [DataType(DataType.EmailAddress)]
    public string? Email { get; set; }
    [Required]
    [DataType(DataType.Password)]
    public string? Password { get; set; }

    public string? ErrorMessages { get; set; }
}
