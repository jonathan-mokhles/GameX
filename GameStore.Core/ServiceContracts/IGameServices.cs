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
        Task<IEnumerable<GameResponseDTO>> GetDiscountedGamesAsync();
        Task AddGameAsync(GameAddRequestDTO gameAddRequest);
        Task UpdateGameAsync(GameUpdateRequestDTO gameUpdateRequest);
        Task DeleteGameAsync(int id);
        Task UpdateStockAsync(int id, int quantity);
    }
}
