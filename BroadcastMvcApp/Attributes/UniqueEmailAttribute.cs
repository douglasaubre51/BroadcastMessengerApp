using System;
using System.ComponentModel.DataAnnotations;
using BroadcastMvcApp.Data;

namespace BroadcastMvcApp.Attributes;

public class UniqueEmailAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        var _context = (ApplicationDbContext)validationContext.GetService(typeof(ApplicationDbContext));

        var email = value?.ToString();

        if (email == null)
        {
            return new ValidationResult("Email field is empty!");
        }

        bool isEmailDuplicate = _context.Accounts.Any(a => a.Email == email);

        if (isEmailDuplicate)
        {
            return new ValidationResult("email already exists!");
        }

        return ValidationResult.Success;
    }
}
