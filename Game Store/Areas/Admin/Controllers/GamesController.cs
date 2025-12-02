using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;


namespace Game_Store.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]")]
    [Authorize(Roles = "Admin")]
    public class GamesController : Controller
    {
        [HttpGet("index")]
        [HttpGet("")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
