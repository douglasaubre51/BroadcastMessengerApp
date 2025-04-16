using BroadcastMvcApp.Interface;
using BroadcastMvcApp.Models;
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
            var messages = await _channelRepository?.GetChannelMessages(id);

            if (messages is null)
            {
                return Json(null);
            }

            return Json(messages);
        }

        [HttpPost]
        public async Task<ActionResult> SendMessage([FromBody] Post post)
        {
            // show payload!
            Console.WriteLine("got payload:-");
            Console.WriteLine(post.Id);
            Console.WriteLine(post.Body);
            Console.WriteLine(post.CreatedDate);

            DateOnly date;
            DateOnly.TryParse(post.CreatedDate, out date);
            Console.WriteLine($"date:{date}");

            var message = new Message
            {
                Data = post.Body,
            };

            await _channelRepository.SetChannelMessage(post.Id, message);

            return RedirectToAction("Index");
        }
    }
}
