using GameStore.Core.Domain.Entities;
using GameStore.Core.Domain.RepositoryContracts;
using GameStore.Infrastructure.DbContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Infrastructure.Repositories
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public ReviewRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        async public Task AddAsync(Review review)
        {
            _dbContext.Reviews.Add(review);
            await _dbContext.SaveChangesAsync();
        }
        async public Task DeleteAsync(int id)
        {
            var review = await _dbContext.Reviews.FindAsync(id);
            if (review != null)
            {
                _dbContext.Reviews.Remove(review);
                await _dbContext.SaveChangesAsync();
            }
        }
        async public Task<Review> GetByIdAsync(int id)
        {     
            return await _dbContext.Reviews.Include(r => r.Game).FirstOrDefaultAsync(r => r.Id == id);
        }     
        async public Task<IEnumerable<Review>> GetReviewsByGameAsync(int gameId)
        {     
            return await _dbContext.Reviews.Include(r => r.Game).Where(r => r.GameId == gameId).ToListAsync();
        }     
        async public Task<IEnumerable<Review>> GetReviewsByUserAsync(int userId)
        {     
            return await _dbContext.Reviews.Include(r => r.Game).Where(r => r.Id == userId).ToListAsync();
        }     
        async public Task<bool> HasUserReviewedGameAsync(int userId, int gameId)
        {     
            return await _dbContext.Reviews.AnyAsync(r => r.Id == userId && r.GameId == gameId);
        }     
        async public Task UpdateAsync(Review review)
        {
            _dbContext.Reviews.Update(review);
            await _dbContext.SaveChangesAsync();
        }

        Task<Review> IReviewRepository.AddAsync(Review review)
        {
            throw new NotImplementedException();
        }

        Task<bool> IReviewRepository.DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<bool> IReviewRepository.ExistsAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<Review>> IReviewRepository.GetAllAsync()
        {
            throw new NotImplementedException();
        }

        Task<double> IReviewRepository.GetAverageRatingByGameIdAsync(int gameId)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<Review>> IReviewRepository.GetByGameIdAsync(int gameId)
        {
            throw new NotImplementedException();
        }

        Task<Review?> IReviewRepository.GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<Review>> IReviewRepository.GetByUserIdAsync(string userId)
        {
            throw new NotImplementedException();
        }

        Task<bool> IReviewRepository.HasUserReviewedGameAsync(string userId, int gameId)
        {
            throw new NotImplementedException();
        }

        Task<Review> IReviewRepository.UpdateAsync(Review review)
        {
            throw new NotImplementedException();
        }
    }
}
