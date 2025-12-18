using GameStore.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Core.Domain.RepositoryContracts
{
    public interface IGameRepository
    {
        Task<Game> GetByIdAsync(int id);
        Task AddAsync(Game game);
        Task UpdateAsync(Game game);
        Task DeleteAsync(int id);
        Task<IEnumerable<Game>> GetAllGamesAsync();
        Task<IEnumerable<Game>> GetGamesByGenreAsync(int genreId);
        Task<IEnumerable<Game>> GetGamesByPlatformAsync(int platformId);
        Task<IEnumerable<Game>> SearchGamesAsync(string searchTerm);

    }
}
