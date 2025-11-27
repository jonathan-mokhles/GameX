using GameStore.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Core.ServiceContracts
{
    public interface IReviewService
    {
        Task<ReviewResponseDTO?> GetReviewByIdAsync(int id);
        Task<IEnumerable<ReviewResponseDTO>> GetAllReviewsAsync();
        Task<IEnumerable<ReviewResponseDTO>> GetReviewsByGameIdAsync(int gameId);
        Task<IEnumerable<ReviewResponseDTO>> GetReviewsByUserIdAsync(string userId);
        Task<ReviewResponseDTO> AddReviewAsync(ReviewAddRequestDTO reviewAddRequest);
        Task<ReviewResponseDTO> UpdateReviewAsync(ReviewUpdateRequestDTO reviewUpdateRequest);
        Task<bool> DeleteReviewAsync(int id);
        Task<double> GetAverageRatingByGameIdAsync(int gameId);
        Task<bool> HasUserReviewedGameAsync(string userId, int gameId);
    }
}
