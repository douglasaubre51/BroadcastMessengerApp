using BroadcastMvcApp.Interface;
using BroadcastMvcApp.Models;
using BroadcastMvcApp.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BroadcastMvcApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<Account> _user;
        private readonly SignInManager<Account> _signIn;
        private readonly IPhotoService _photoService;
        private readonly IAuthorizationService _authorizationService;
        public AccountController(SignInManager<Account> signIn, UserManager<Account> user, IPhotoService photoService, IAuthorizationService authorizationService)
        {
            _signIn = signIn;
            _user = user;
            _photoService = photoService;
            _authorizationService = authorizationService;
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(CreateAccountViewModel createVM)
        {
            bool isAuthorized = _authorizationService.CheckUserAuthentication(createVM, ModelState);

            if (ModelState.IsValid)
            {
                if (isAuthorized)
                {
                    var photoUrl = await _photoService.AddPhotoAsync(createVM.ProfilePhoto);

                    var account = new Account()
                    {
                        UserName = createVM.Email,
                        Name = createVM.Name,
                        Email = createVM.Email,
                        roles = createVM.roles,
                        departments = createVM.departments,
                        semesters = createVM.semesters,
                        ProfilePhotoURL = photoUrl.Url.ToString(),
                    };

                    await _user.CreateAsync(account, createVM.Password);

                    await _signIn.SignInAsync(account, isPersistent: true);

                    return RedirectToAction("Index", "Home");
                }

                else
                {
                    ModelState.AddModelError("Authorization", "invalid authentication key!");
                    return View(createVM);
                }
            }

            return View(createVM);
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Login(LoginAccountViewModel loginVM)
        {
            if (ModelState.IsValid)
            {
                var result = await _signIn.PasswordSignInAsync(loginVM.Email, loginVM.Password, isPersistent: true, lockoutOnFailure: false);

                if (!result.Succeeded)
                {
                    ModelState.AddModelError("Email", "invalid email or password!");
                    return View(loginVM);
                }

                var account = await _user.FindByNameAsync(loginVM.Email);

                if (account.roles == Enum.Roles.Admin)
                    return RedirectToAction("Index", "Admin");

                if (account.roles == Enum.Roles.Tutor)
                {
                    return RedirectToAction("Index", "Tutor");
                }

                return RedirectToAction("Index", "Home");
            }
            return View(loginVM);
        }
    }
}
