using BroadcastMvcApp.Interface;
using BroadcastMvcApp.Models;
using BroadcastMvcApp.Services;
using BroadcastMvcApp.ViewModels.Account;
using Microsoft.AspNetCore.Mvc;
namespace BroadcastMvcApp.Controllers;
public class AccountController(
        IAccountRepository accountRepository,
        PhotoService photoService,
        AuthorizationService authorizationService
    )
    : Controller
{
    private readonly IAccountRepository _accountRepository = accountRepository;
    private readonly PhotoService _photoService = photoService;
    private readonly AuthorizationService _authorizationService = authorizationService;

    public ActionResult Login() => View();
    public ActionResult Create() => View();

    [HttpPost]
    public async Task<ActionResult> Login(LoginViewModel viewModel)
    {
        if (ModelState.IsValid is false) View();

        try
        {
            var account = await _accountRepository.GetByEmail(viewModel.Email);
            if (account is null)
            {
                ModelState.AddModelError("Email", "User doesnot exists!");
                return View(viewModel);
            }
            if (account.Password != viewModel.Password)
            {
                ModelState.AddModelError("Password", "Invalid password!");
                return View(viewModel);
            }

            if (account.Role == Enum.Roles.Admin)
                return RedirectToAction("Index", "Admin");

            if (account.Role == Enum.Roles.Tutor)
            {
                HttpContext.Session.SetInt32("AccountId", account.Id);
                return RedirectToAction("Index", "Tutor");
            }

            // for student
            return RedirectToAction("Index", "Home");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"LoginAccount error: {ex.Message}");
            return View();
        }
    }

    [HttpPost]
    public async Task<ActionResult> Create(CreateViewModel viewModel)
    {
        if (ModelState.IsValid is false)
            return View(viewModel);

        bool isAuthorized = _authorizationService
            .CheckUserAuthentication(viewModel, ModelState);
        if (isAuthorized is false)
        {
            ModelState.AddModelError(
                nameof(CreateViewModel.Authorization),
                "Invalid auth key!"
                );
            return View(viewModel);
        }

        try
        {
            string photoUrl = string.Empty;

            if (viewModel.Profile is not null)
                photoUrl = await _photoService.AddPhotoAsync(viewModel.Profile);

            var account = new Account()
            {
                FirstName = viewModel.FirstName,
                LastName = viewModel.LastName,
                Email = viewModel.Email,
                Password = viewModel.Password,
                Role = viewModel.Role,
                Department = viewModel.Department,
                Semester = viewModel.Semester,
                Profile = photoUrl,
            };

            _accountRepository.Add(account);

            if (account.Role == Enum.Roles.Admin)
                return RedirectToAction("Index", "Admin");

            // for teacher and student
            return RedirectToAction("Index", "Home");
        }
        catch (Exception ex)
        {
            Console.WriteLine("CreateAccount error: " + ex.Message);
            return View();
        }
    }
}
