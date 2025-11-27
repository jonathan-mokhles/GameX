using GameStore.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Core.Domain.RepositoryContracts
{
    public  interface IOrderRepository
    {
        Task<Order> GetByIdAsync(int id);
        Task<Order> GetOrderWithDetailsAsync(int id); // includes OrderDetails
        Task<IEnumerable<Order>> GetOrdersByUserAsync(string userId);
        Task<IEnumerable<Order>> GetAllOrdersAsync();
        Task<Order> CreateOrderAsync(Order order); // saves order + details in one transaction
        Task UpdateOrderStatusAsync(int orderId, string status);
    }
}

