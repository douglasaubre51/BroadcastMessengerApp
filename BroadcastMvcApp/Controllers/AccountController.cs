using BroadcastMvcApp.Interface;
using BroadcastMvcApp.Models;
using BroadcastMvcApp.ViewModels;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Mvc;

namespace BroadcastMvcApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly IPhotoService _photoService;
        private readonly IAccountRepository _repository;
        public AccountController(IAccountRepository repository, IPhotoService photoService)
        {
            _repository = repository;
            _photoService = photoService;
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Create(CreateAccountViewModel createVM)
        {
            if (ModelState.IsValid)
            {

                var imageUrl = await _photoService.AddPhotoAsync(createVM.ProfilePhoto);

                var model = new Account
                {
                    Username = createVM.Username,
                    Email = createVM.Email,
                    Password = createVM.Password,
                    ProfilePhotoURL = imageUrl.Url.ToString(),
                    roles = createVM.roles,
                    departments = createVM.departments,
                    semesters = createVM.semesters
                };

                _repository.Add(model);

                return RedirectToAction("Login");
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

                if (model.Password != loginVM.Password)
                {
                    loginVM.ErrorMessages = "incorrect password!";
                    return View(loginVM);
                }

                HttpContext.Session.SetInt32("AccountId", model.AccountId);

                if (model.roles == Enum.Roles.Admin)
                    return RedirectToAction("Index", "Admin");

                return RedirectToAction("Index", "Home");
            }
            return View(loginVM);
        }

    }
}
