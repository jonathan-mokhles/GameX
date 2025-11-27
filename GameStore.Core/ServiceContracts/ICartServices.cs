using GameStore.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Core.ServiceContracts
{
    public interface ICartService
    {
        Task<CartResponseDTO?> GetCartByIdAsync(int id);
        Task<CartResponseDTO?> GetCartByUserIdAsync(string userId);
        Task<CartResponseDTO> CreateCartAsync(string userId);
        Task<CartItemResponseDTO> AddItemToCartAsync(CartItemAddRequestDTO cartItemAddRequest);
        Task<CartItemResponseDTO> UpdateCartItemQuantityAsync(int cartItemId, int quantity);
        Task<bool> RemoveItemFromCartAsync(int cartItemId);
        Task<bool> ClearCartAsync(int cartId);
        Task<decimal> GetCartTotalAsync(int cartId);
    }
}
