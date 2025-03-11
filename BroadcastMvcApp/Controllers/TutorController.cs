using BroadcastMvcApp.Models;
using System.Threading.Channels;
using BroadcastMvcApp.Interface;
using BroadcastMvcApp.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BroadcastMvcApp.Controllers
{
    public class TutorController : Controller
    {
        private readonly IChannelRepository _channelRepository;
        private readonly IAccountRepository _accountRepository;
        public TutorController(IChannelRepository channelRepository, IAccountRepository accountRepository)
        {
            _channelRepository = channelRepository;
            _accountRepository = accountRepository;
        }

        // GET: TutorController
        public async Task<ActionResult> Index()
        {
            //get session value
            int accountId = (int)HttpContext.Session.GetInt32("AccountId");
            //get account of current user
            var account = await _accountRepository.GetById(accountId);
            //get all channels that include account
            var channels = await _channelRepository.GetByAccount(account);

            var model = new IndexTutorViewModel()
            {
                Channels = channels,
            };


            return View(model);
        }
        [HttpPost]
        public ActionResult Index(IndexTutorViewModel viewModel)
        {
            return View(viewModel);
        }

    }
}
