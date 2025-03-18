using BroadcastMvcApp.Interface;
using BroadcastMvcApp.Models;
using BroadcastMvcApp.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BroadcastMvcApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IPhotoService _photoService;
        private readonly IAuthorizationService _authorizationService;
        public AccountController(IAccountRepository accountRepository, IPhotoService photoService, IAuthorizationService authorizationService)
        {
            _accountRepository = accountRepository;
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
                        UserName = createVM.Name,
                        Email = createVM.Email,
                        Password = createVM.Password,
                        roles = createVM.roles,
                        departments = createVM.departments,
                        semesters = createVM.semesters,
                        ProfilePhotoURL = photoUrl.Url.ToString(),
                    };

                    _accountRepository.Add(account);

                    if (account.roles == Enum.Roles.Admin)
                        return RedirectToAction("Index", "Admin");

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
                var account = await _accountRepository.GetByEmail(loginVM.Email);

                if (account == null)
                {
                    ModelState.AddModelError("Email", "emailId doesnot exists!");

                    return View(loginVM);
                }

                if (account.Password != loginVM.Password)
                {
                    ModelState.AddModelError("Password", "passwords does not match!");

                    return View(loginVM);
                }

                if (account.roles == Enum.Roles.Admin)
                    return RedirectToAction("Index", "Admin");

                if (account.roles == Enum.Roles.Tutor)
                    return RedirectToAction("Index", "Tutor");

                return RedirectToAction("Index", "Home");
            }
            return View(loginVM);
        }
    }
}
