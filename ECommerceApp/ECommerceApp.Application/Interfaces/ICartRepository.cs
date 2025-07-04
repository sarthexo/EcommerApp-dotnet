using ECommerceApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Application.Interfaces
{
   public interface ICartRepository
    {
        Task<Cart> GetByUserIdAsync(Guid userId);
        Task AddItemAsync(Guid userId, Guid productId, int quantity);
        Task RemoveItemAsync(Guid userId, Guid productId);
        Task ClearCartAsync(Guid userId);

        Task UpdateQuantityAsync(Guid userId, Guid productId, int newQuantity);

    }
}
