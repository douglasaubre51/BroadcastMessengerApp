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

        // GET: user cards showcase and admin page
        public async Task<ActionResult> Index()
        {
            IEnumerable<Account> accounts = await _accountRepository.GetAll();
            IEnumerable<Channel> channels = await _channelRepository.GetAll();

            var viewModel = new IndexAdminViewModel();
            viewModel.accounts = accounts;
            viewModel.channels = channels;

            return View(viewModel);
        }
        //create new channel page
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

        //add a user to selected channel
        public async Task<IActionResult> AddToSelectChannel(int userId, string channelName)
        {
            var account = await _accountRepository.GetById(userId);

            await _channelRepository.AddToChannel(account, channelName);

            return RedirectToAction("Index");
        }
    }
}
