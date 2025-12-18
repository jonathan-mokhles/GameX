using GameStore.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Core.ServiceContracts
{
    public interface IGameService
    {
        Task<GameResponseDTO?> GetGameByIdAsync(int id);
        Task<IEnumerable<GameResponseDTO>> GetAllGamesAsync();
        Task<IEnumerable<GameResponseDTO>> GetGamesByGenreAsync(int genreId);
        Task<IEnumerable<GameResponseDTO>> GetGamesByPlatformAsync(int platformId);
        Task<IEnumerable<GameResponseDTO>> SearchGamesByTitleAsync(string title);
        Task<IEnumerable<GameResponseDTO>> GetDiscountedGamesAsync();
        Task<IEnumerable<GameResponseDTO>> GetInStockGamesAsync();
        Task AddGameAsync(GameAddRequestDTO gameAddRequest);
        Task<GameResponseDTO> UpdateGameAsync(GameUpdateRequestDTO gameUpdateRequest);
        Task DeleteGameAsync(int id);
        Task UpdateStockAsync(int id, int quantity);
    }
}
