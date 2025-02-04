using Azure.Identity;
using BroadcastMvcApp.Interface;
using BroadcastMvcApp.Models;
using BroadcastMvcApp.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BroadcastMvcApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountRepository _repository;
        public AccountController(IAccountRepository repository)
        {
            _repository = repository;
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(CreateAccountViewModel createVM)
        {
            if (ModelState.IsValid)
            {
                var model = new Account
                {
                    Username = createVM.Username,
                    Email = createVM.Email,
                    Password = createVM.Password,
                    ProfilePhotoURL = "",
                    roles = createVM.roles,
                    departments = createVM.departments,
                    semesters = createVM.semesters
                };

                _repository.Add(model);

                return RedirectToAction("Index", "Home");
            }
            return View(createVM);
        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginAccountViewModel loginVM)
        {
            if (ModelState.IsValid)
            {
                var model = _repository.GetByEmail(loginVM.Email);

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

                return RedirectToAction("Index", "Home");
            }
            return View(loginVM);
        }

    }
}
