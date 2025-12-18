using GameStore.Core.DTO;
using GameStore.Core.ServiceContracts;
using Microsoft.AspNetCore.Mvc;

namespace Game_Store.Controllers
{
    [Route("[controller]/[action]")]
    public class GameController : Controller
    {
        private readonly IGameService _gameService;
        public GameController(IGameService gameService)
        {
            _gameService = gameService;
        }

        [Route("{id}")]
        async public Task<IActionResult> details(int id)
        {
            GameResponseDTO? game =  await _gameService.GetGameByIdAsync(id);
            if (game == null)
            {
                return NotFound();
            }
            return View(game);
        }
    }
}
