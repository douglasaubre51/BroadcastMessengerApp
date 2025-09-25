using Microsoft.AspNetCore.Mvc;

namespace BroadcastMvcApp.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
