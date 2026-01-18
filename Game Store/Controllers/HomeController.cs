using System.Diagnostics;
using GameStore.Core.DTO;
using GameStore.Core.ServiceContracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Game_Store.Controllers
{
    [AllowAnonymous]
    [Route("[controller]/[action]")]
    public class HomeController : Controller
    {
        private readonly IGameService _gameService;

        public HomeController(IGameService gameService)
        {
            _gameService = gameService;
        }

        [Route("/")]
        public async Task<IActionResult> Index()
        {
            IEnumerable<GameResponseDTO> Games = await _gameService.GetAllGamesAsync();
            return View(Games);
        }

        public IActionResult About()
        {
            return View();
        }

    }
}
