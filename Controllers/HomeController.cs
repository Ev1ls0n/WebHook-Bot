using Microsoft.AspNetCore.Mvc;

namespace WebHookBot.Controllers
{
    public class HomeController : Controller
    {
        public string Index()
        {
            return "It's HomeController.";
        }
    }
}
