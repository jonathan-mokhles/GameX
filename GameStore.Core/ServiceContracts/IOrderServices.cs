using GameStore.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Core.ServiceContracts
{
    public interface IOrderService
    {
        Task<OrderResponseDTO?> GetOrderByIdAsync(int id);
        Task<IEnumerable<OrderResponseDTO>> GetAllOrdersAsync();
        Task<IEnumerable<OrderResponseDTO>> GetOrdersByUserIdAsync(string userId);
        Task<IEnumerable<OrderResponseDTO>> GetOrdersByStatusAsync(string status);
        Task<OrderResponseDTO> CreateOrderAsync(OrderAddRequestDTO orderAddRequest);
        Task<OrderResponseDTO> UpdateOrderAsync(OrderUpdateRequestDTO orderUpdateRequest);
        Task<bool> DeleteOrderAsync(int id);
        Task<bool> UpdateOrderStatusAsync(int orderId, string status);
        Task<decimal> GetTotalRevenueAsync();
        Task<IEnumerable<OrderResponseDTO>> GetOrdersByDateRangeAsync(DateTime startDate, DateTime endDate);
    }
}
