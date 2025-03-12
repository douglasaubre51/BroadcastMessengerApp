using BroadcastMvcApp.Interface;
using BroadcastMvcApp.Models;
using BroadcastMvcApp.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BroadcastMvcApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly IPhotoService _photoService;
        private readonly IAuthorizationService _authorizationService;
        private readonly IAccountRepository _repository;
        public AccountController(IAccountRepository repository, IPhotoService photoService, IAuthorizationService authorizationService)
        {
            _repository = repository;
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

                    var model = new Account()
                    {
                        // Username = createVM.Username,
                        Email = createVM.Email,
                        // Password = createVM.Password,
                        roles = createVM.roles,
                        departments = createVM.departments,
                        semesters = createVM.semesters,
                        ProfilePhotoURL = photoUrl.Url.ToString(),
                    };

                    _repository.Add(model);
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
                var model = await _repository.GetByEmail(loginVM.Email);

                if (model == null)
                {
                    loginVM.ErrorMessages = "email doesnot exist!";
                    return View(loginVM);
                }

                // if (model.Password != loginVM.Password)
                // {
                //     loginVM.ErrorMessages = "incorrect password!";
                //     return View(loginVM);
                // }


                if (model.roles == Enum.Roles.Admin)
                    return RedirectToAction("Index", "Admin");

                if (model.roles == Enum.Roles.Tutor)
                {
                    // HttpContext.Session.SetInt32("AccountId", model.AccountId);
                    return RedirectToAction("Index", "Tutor");
                }

                return RedirectToAction("Index", "Home");
            }
            return View(loginVM);
        }
    }
}
