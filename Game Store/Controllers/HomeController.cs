using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace Game_Store.Controllers
{
    [Route("[controller]/[action]")]
    public class HomeController : Controller
    {

        [Route("/")]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

    }
}
