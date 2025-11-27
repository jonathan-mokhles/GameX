using GameStore.Core.Domain.Entities;
using GameStore.Core.Domain.RepositoryContracts;
using GameStore.Infrastructure.DbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Infrastructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public OrderRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        async Task<Order> IOrderRepository.CreateOrderAsync(Order order)
        {
            throw new NotImplementedException();

        }
        async Task<IEnumerable<Order>> IOrderRepository.GetAllOrdersAsync()
        {
            throw new NotImplementedException();
        }
         
        async Task<Order> IOrderRepository.GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
        async Task<IEnumerable<Order>> IOrderRepository.GetOrdersByUserAsync(string userId)
        {
            throw new NotImplementedException();
        }
         
        async Task<Order> IOrderRepository.GetOrderWithDetailsAsync(int id)
        {
            throw new NotImplementedException();
        }
         
        async Task IOrderRepository.UpdateOrderStatusAsync(int orderId, string status)
        {
            throw new NotImplementedException();
        }
    }
}
