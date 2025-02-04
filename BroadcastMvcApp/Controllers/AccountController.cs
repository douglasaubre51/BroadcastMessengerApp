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
                return RedirectToAction("Index", "Home");
            }
            return View(loginVM);
        }

    }
}
