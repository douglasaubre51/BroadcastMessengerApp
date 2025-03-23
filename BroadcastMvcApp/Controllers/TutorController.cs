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
            if (HttpContext.Session.GetInt32("AccountId") == null)
            {
                return RedirectToAction("Login", "Account");
            }

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
        //get messages from selected channel
        [HttpGet]
        public async Task<JsonResult> GetMessages(int id)
        {
            Console.WriteLine("step into 1");
            var channel = await _channelRepository.GetChannelMessages(id);
            Console.WriteLine("step into 2");
            Console.WriteLine($"{channel is null}");
            channel.ForEach(e => Console.WriteLine(e.Data));
            return Json(channel);
        }
    }
}