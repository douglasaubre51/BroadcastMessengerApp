using System;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using BroadcastMvcApp.Interface;
using BroadcastMvcApp.ViewModels;

namespace BroadcastMvcApp.Services;

public class AuthorizationService : IAuthorizationService
{
    private readonly string _adminAuthKey;
    private readonly string _tutorAuthKey;

    public AuthorizationService()
    {
        _adminAuthKey = "chancellor66";
        _tutorAuthKey = "helldivers";
    }
    public bool CheckUserAuthentication(CreateAccountViewModel createVM, ModelStateDictionary modelState)
    {
        if (createVM.roles == Enum.Roles.Admin)
        {
            modelState.Remove("departments");
            modelState.Remove("semesters");
            if (createVM.Authorization == _adminAuthKey)
            {
                return true;
            }

            return false;
        }

        else if (createVM.roles == Enum.Roles.Tutor)
        {
            modelState.Remove("semesters");
            if (createVM.Authorization == _tutorAuthKey)
            {
                return true;
            }

            return false;
        }

        else
        {
            modelState.Remove("Authorization");
            return true;
        }
    }
}