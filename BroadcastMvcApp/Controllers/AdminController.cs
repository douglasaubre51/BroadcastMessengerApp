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

            var viewModel = new IndexAdminViewModel();

            viewModel.accounts = accounts;

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
        //popup window for showing list of channels to add user to
        public IActionResult AddChannelList()
        {
            return PartialView("AddChannelList");
        }
        [HttpPost]
        public IActionResult AddChannelList(AddChannelListAdminViewModel viewModel)
        {
            foreach (ChannelList i in viewModel.channelLists)
            {
                if (i.IsChecked == true)
                {
                    var channel = new Channel();
                }
            }

            return View("Index");
        }
        public IActionResult RemoveChannelList()
        {
            return View();
        }
    }
}
