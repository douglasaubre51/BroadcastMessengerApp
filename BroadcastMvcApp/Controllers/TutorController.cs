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
        private readonly IMessageRepository _messageRepository;


        public TutorController(IChannelRepository channelRepository, IAccountRepository accountRepository,IMessageRepository messageRepository)
        {
            _channelRepository = channelRepository;
            _accountRepository = accountRepository;
            _messageRepository = messageRepository;
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

	    Console.WriteLine(accountId);

            var model = new IndexTutorViewModel()
            {
                Channels = channels,
			 AccountId=accountId
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
            Console.WriteLine(post.AccountId);
            Console.WriteLine(post.Body);
            Console.WriteLine(post.CreatedDate);
            Console.WriteLine(post.CreatedTime);

            // create date
            DateOnly date;
            DateOnly.TryParse(post.CreatedDate, out date);

            // create time
            TimeOnly time;
            TimeOnly.TryParse(post.CreatedTime, out time);

            // create date time
            DateTime dateTime;
            DateTime.TryParse(date + " " + time, out dateTime);
            Console.WriteLine(dateTime);

	    var channel=await _channelRepository.GetById(post.Id);
	    var account=await _accountRepository.GetById(post.AccountId);

            var message = new Message
            {
	      Channel=channel,
		Account=account,
                Data = post.Body,
                UploadDateTime = dateTime
            };

            _messageRepository.Add( message);

            return RedirectToAction("Index");
        }
    }
}
