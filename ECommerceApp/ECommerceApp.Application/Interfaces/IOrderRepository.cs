using ECommerceApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Application.Interfaces
{
   public interface IOrderRepository
    {
        Task CreateOrderAsync(Order order,List<OrderItem> items);
        Task<Order?> GetByIdAsync(Guid orderId);
        Task<List<Order>> GetByUserIdAsync(Guid userId);
        Task<List<Order>> GetAllAsync(); //For Admins/SuperAdmin
        Task UpdateAsync(Order order);
        Task DeleteAsync(Order order);

    }
}
