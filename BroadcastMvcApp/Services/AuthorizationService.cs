using BroadcastMvcApp.Enum;
using BroadcastMvcApp.ViewModels.Account;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BroadcastMvcApp.Services;

public class AuthorizationService
{
    private readonly string _adminAuthKey = "chancellor66";
    private readonly string _tutorAuthKey = "helldivers";

    public bool CheckUserAuthentication(
        CreateViewModel viewModel,
        ModelStateDictionary modelState
        )
    {
        switch (viewModel.Role)
        {
            case Roles.Admin:
                if (viewModel.Authorization != _adminAuthKey)
                    return false;
                return true;

            case Roles.Tutor:
                if (viewModel.Authorization != _tutorAuthKey)
                    return false;
                return true;

            default:
                Console.WriteLine("Role doesnot match!");
                return false;
        }
    }
}