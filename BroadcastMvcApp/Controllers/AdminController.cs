using BroadcastMvcApp.Interface;
using BroadcastMvcApp.Models;
using BroadcastMvcApp.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BroadcastMvcApp.Controllers
{
    public class AdminController : Controller
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IChannelRepository _channelRepository;

        public AdminController(IAccountRepository accountRepository, IChannelRepository channelRepository)
        {
            _accountRepository = accountRepository;
            _channelRepository = channelRepository;
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

        public IActionResult CreateChannel()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateChannel(CreateChannelAdminViewModel createChannelVM)
        {
            if (ModelState.IsValid)
            {
                string name = createChannelVM.ChannelName;

                Channel channel = new Channel
                {
                    ChannelName = name,
                };

                _channelRepository.Add(channel);

                return RedirectToAction("Index");
            }

            return View(createChannelVM);
        }
    }
}
