using System;
using BroadcastMvcApp.Models;
using System.ComponentModel.DataAnnotations;

namespace BroadcastMvcApp.ViewModels;

public class CreateAccountViewModel : Account
{
    [Required]
    [DataType(DataType.Password)]
    [Compare("Password", ErrorMessage = "passwords do not match!")]
    public string? ConfirmPassword { get; set; }

    [Required]
    public IFormFile? ProfilePhoto { get; set; }
}
