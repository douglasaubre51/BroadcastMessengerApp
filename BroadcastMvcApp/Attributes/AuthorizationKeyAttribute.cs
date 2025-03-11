using System;
using BroadcastMvcApp.Enum;
using System.ComponentModel.DataAnnotations;

namespace BroadcastMvcApp.Attributes;

public class AuthorizationKeyAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        string authKey = value?.ToString();

        if (authKey == null)
        {
            return new ValidationResult("empty auth field!");
        }

        string adminPassKey = "chancellor66";

        if (authKey == adminPassKey)
            return ValidationResult.Success;

        else
            return new ValidationResult("wrong auth key!");
    }
}
