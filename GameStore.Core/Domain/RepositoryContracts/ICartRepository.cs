using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameStore.Core.Domain.Entities;

namespace GameStore.Core.Domain.RepositoryContracts
{
    public interface ICartRepository
    {
        Task<Cart?> GetByIdAsync(int id);
        Task<Cart?> GetByUserIdAsync(string userId);
        Task<Cart> AddAsync(Cart cart);
        Task<Cart> UpdateAsync(Cart cart);
        Task<bool> DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
        Task<bool> ClearCartAsync(int cartId);
        Task<decimal> GetCartTotalAsync(int cartId);
    }
    }
