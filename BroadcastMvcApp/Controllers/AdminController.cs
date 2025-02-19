using BroadcastMvcApp.Interface;
using BroadcastMvcApp.Models;
using BroadcastMvcApp.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BroadcastMvcApp.Controllers
{
    public class AdminController : Controller
    {
        private readonly IAccountRepository _accountRepository;

        public AdminController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        // GET: AdminController
        public async Task<ActionResult> Index()
        {
            IEnumerable<Account> accounts = await _accountRepository.GetAll();

            var viewModel = new IndexAdminViewModel();

            viewModel.accounts = accounts;

            return View(viewModel);
        }

        public async Task<IActionResult> AddToChannel(int userId)
        { return View(); }

        public IActionResult CreateNewChannel()
        {
            return View();
        }

        public IActionResult CreateChannel(Channel channel)
        {
            var viewModel=new 
            return View(viewModel);
        }

    }
}
