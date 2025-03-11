using BroadcastMvcApp.ViewModels;
using BroadcastMvcApp.Enum;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BroadcastMvcApp.Interface;

public interface IAuthorizationService
{
    bool CheckUserAuthentication(CreateAccountViewModel createVM, ModelStateDictionary modelState);
}
