using ECommerceApp.Application.Interfaces;
using ECommerceApp.Domain.Entities;
using ECommerceApp.Infrastructure.Exceptions;
using ECommerceApp.Persistence.DbtContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Persistence.Repositories
{
   public  class OrderRepository:IOrderRepository
    {
        private readonly AppDbContext _context;

        public OrderRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task CreateOrderAsync(Order order, List<OrderItem> items)
        {
            order.OrderItems = items;

            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Order order)
        {
            var existingOrder = await _context.Orders.FindAsync(order.Id);
            if (existingOrder == null)
                throw new NotFoundException("Order Not Found");

            _context.Orders.Remove(existingOrder);
            await _context.SaveChangesAsync();
                
            
        }

        public async Task<List<Order>> GetAllAsync()
        {
            return await _context.Orders
                .Include(o => o.OrderItems)
                .ToListAsync();
        }

        public async Task<Order?> GetByIdAsync(Guid orderId)
        {
            return await _context.Orders
                .Include(o => o.OrderItems)
                .FirstOrDefaultAsync(o => o.Id == orderId);
        }

        public async Task<List<Order>> GetByUserIdAsync(Guid userId)
        {
            return await _context.Orders
                 .Include(o => o.OrderItems)
                 .Where(o => o.UserId == userId)
                 .ToListAsync();
        }

        public async Task UpdateAsync(Order order)
        {
            var existingOrder = await _context.Orders
                .Include(o => o.OrderItems)
                .FirstOrDefaultAsync(o => o.Id == order.Id);

            if (existingOrder == null)
                throw new NotFoundException("Order not found");

            existingOrder.status = order.status;
            existingOrder.TotalAmount = order.TotalAmount;

            _context.Orders.Update(existingOrder);
            await _context.SaveChangesAsync();
        }
    }
}
