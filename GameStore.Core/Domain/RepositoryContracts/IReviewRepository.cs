using GameStore.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Core.Domain.RepositoryContracts
{
    public interface IReviewRepository
    {
        Task<Review?> GetByIdAsync(int id);
        Task<IEnumerable<Review>> GetAllAsync();
        Task<IEnumerable<Review>> GetByGameIdAsync(int gameId);
        Task<IEnumerable<Review>> GetByUserIdAsync(string userId);
        Task<Review> AddAsync(Review review);
        Task<Review> UpdateAsync(Review review);
        Task<bool> DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
        Task<double> GetAverageRatingByGameIdAsync(int gameId);
        Task<bool> HasUserReviewedGameAsync(string userId, int gameId);
    }
}
