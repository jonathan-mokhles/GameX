using GameStore.Core.Domain.Entities;
using GameStore.Core.Domain.RepositoryContracts;
using GameStore.Infrastructure.DbContext;
using Microsoft.EntityFrameworkCore;


namespace GameStore.Infrastructure.Repositories
{
    public class GameRepository : IGameRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public GameRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }   


        Task<Game> IGameRepository.GetByIdAsync(int id)
        {
            return _dbContext.Games.Include(g => g.Genre).Include(g => g.Platform).FirstAsync(g => g.GameId == id);
        }
        async Task IGameRepository.AddAsync(Game game)
        {
             _dbContext.Games.Add(game);
            await _dbContext.SaveChangesAsync();
        }
        async Task IGameRepository.UpdateAsync(Game game)
        {
            _dbContext.Games.Update(game);
            await _dbContext.SaveChangesAsync();
        }
        async Task IGameRepository.DeleteAsync(int id)
        {
            var game = await _dbContext.Games.FindAsync(id);
            if (game != null)
            {
                _dbContext.Games.Remove(game);
                await _dbContext.SaveChangesAsync();
            }
        }

        async Task<IEnumerable<Game>> IGameRepository.GetAllGamesAsync()
        {
            return await _dbContext.Games.Include(g => g.Genre).Include(g => g.Platform).ToListAsync();
        }
        async Task<IEnumerable<Game>> IGameRepository.GetGamesByGenreAsync(int genreId)
        {
            return await _dbContext.Games.Include(g => g.Genre).Include(g => g.Platform).Where(g => g.GenreId == genreId).ToListAsync();
        }
        async Task<IEnumerable<Game>> IGameRepository.GetGamesByPlatformAsync(int platformId)
        {
            return await _dbContext.Games.Include(g => g.Genre).Include(g => g.Platform).Where(g => g.PlatformId == platformId).ToListAsync();
        }
        async Task<IEnumerable<Game>> IGameRepository.SearchGamesAsync(string searchTerm)
        {
            return await _dbContext.Games
                .Include(g => g.Genre)
                .Include(g => g.Platform)
                .Where(g => g.Title.Contains(searchTerm) || g.Description.Contains(searchTerm))
                .ToListAsync();
        }

        async Task<Genre> IGameRepository.GetGenreByIdAsync(int id)
        {
            return await _dbContext.Genres.FirstAsync(g => g.Id == id);
        }
        async Task<Platform> IGameRepository.GetPlatformByIdAsync(int id)
        {
            return await _dbContext.Platforms.FirstAsync(p => p.Id == id);
        }
        async Task<IEnumerable<Genre>> IGameRepository.GetAllGenresAsync()
        {
            return await _dbContext.Genres.ToListAsync();
        }
        async Task<IEnumerable<Platform>> IGameRepository.GetAllPlatformsAsync()
        {
            return await _dbContext.Platforms.ToListAsync();
        }

    }
}
