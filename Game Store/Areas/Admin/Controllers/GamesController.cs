using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using GameStore.Core.ServiceContracts;
using GameStore.Core.DTO;


namespace Game_Store.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]")]
    [Authorize(Roles = "Admin")]
    public class GamesController : Controller
    {
        private readonly IGameService _gameService;
        private readonly IGenreService _genreService;
        private readonly IPlatformService _platformService;
        public GamesController(IGameService gameService, IGenreService genreService, IPlatformService platformService)
        {
            _gameService = gameService;
            _genreService = genreService;
            _platformService = platformService;
        }
        [HttpGet("index")]
        [HttpGet("")]
        public async Task<IActionResult> Index()
        {
            IEnumerable<GameResponseDTO> games = await _gameService.GetAllGamesAsync();
            ViewBag.GamesClass = new Dictionary<string,string>
            {
                { "Action", "action" },
                { "Adventure", "adventure" },
                { "RPG", "rpg" },
                { "Strategy", "strategy" },
                { "Simulation", "simulation" },
                { "Sports", "sports" },
                { "Horror", "horror" },
                { "Racing", "racing" },
                { "PlayStation 5", "ps5" },
                { "PlayStation 4", "ps4" },
                { "Xbox Series X/S", "xbox" },
                { "Xbox One", "xbox" },
                { "Nintendo Switch", "switch" },
                { "PC", "pc" },
            };

            //ViewBag.GenreSelectItems = await _genreService.GetAllSelectListItemAsync();
            //ViewBag.PlatformSelectItems = await _platformService.GetPlatformSelectListItemsAsync();



            return View(games);
        }

        [HttpGet("Add")]
        public async Task<IActionResult> Add()
        {
            ViewBag.GenreSelectItems = await _genreService.GetAllSelectListItemAsync();
            ViewBag.PlatformSelectItems = await _platformService.GetPlatformSelectListItemsAsync();
            return View();
        }

        [HttpPost("Add")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(GameAddRequestDTO gameAddRequest)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.GenreSelectItems = await _genreService.GetAllSelectListItemAsync();
                ViewBag.PlatformSelectItems = await _platformService.GetPlatformSelectListItemsAsync();
                return View(gameAddRequest);
            }
            await _gameService.AddGameAsync(gameAddRequest);
            return RedirectToAction(nameof(Index));

        }


        public async Task<IActionResult> Delete(int id)
        {
            await _gameService.DeleteGameAsync(id);
            return RedirectToAction("Index");
        }
    }
}
