using Microsoft.AspNetCore.Mvc;

namespace Nevus.UI.Controllers
{
    public class ChatController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
