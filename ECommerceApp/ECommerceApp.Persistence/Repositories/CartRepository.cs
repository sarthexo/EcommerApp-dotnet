using ECommerceApp.Application.Interfaces;
using ECommerceApp.Domain.Entities;
using ECommerceApp.Persistence.DbtContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Persistence.Repositories
{
   public  class CartRepository:ICartRepository
    {
        private readonly AppDbContext _context;
        public CartRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddItemAsync(Guid userId, Guid productId, int quantity)
        {
            var cart = await _context.Carts
                .Include(c => c.Items)
                .FirstOrDefaultAsync(c => c.UserId == userId);

            if (cart == null )
            {
                cart = new Cart { UserId = userId };
                _context.Carts.Add(cart);
            }
            var existingItem = cart.Items.FirstOrDefault(i => i.ProductId == productId);
            if (existingItem != null)
            {
                existingItem.Quantity += quantity;
            }
            else
            {
                var product = await _context.Products.FindAsync(productId);
                if (product == null)
                {
                    throw new InvalidOperationException("Product not found");
                }

                cart.Items.Add(new CartItem
                {
                    ProductId = product.Id,
                    ProductName = product.Name,
                    Quantity = quantity,
                    Price = product.Price
                });
            }
            await _context.SaveChangesAsync();
        }

        public async Task ClearCartAsync(Guid userId)
        {
            var cart = await _context.Carts
                .Include(c => c.Items)
                .FirstOrDefaultAsync(c => c.UserId == userId);

            if (cart != null)
            {
                cart.Items.Clear();
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Cart> GetByUserIdAsync(Guid userId)
        {
            var cart = await _context.Carts
                .Include(c => c.Items)
                .FirstOrDefaultAsync(c => c.UserId == userId);

            return cart ?? new Cart { UserId = userId };
        }

        public async Task RemoveItemAsync(Guid userId, Guid productId)
        {
            var cart = await _context.Carts
                .Include(c => c.Items)
                .FirstOrDefaultAsync(c => c.UserId == userId);

            if (cart == null)
                throw new InvalidOperationException("Cart not found");

            var item = cart.Items.FirstOrDefault(i => i.ProductId == productId);
            if (item == null)
                throw new InvalidOperationException("Item not found");

            cart.Items.Remove(item);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateQuantityAsync(Guid userId, Guid productId, int newQuantity)
        {
            var cart = await _context.Carts
                .Include(c => c.Items)
                .FirstOrDefaultAsync(c => c.UserId == userId);

            if (cart == null)
                throw new InvalidOperationException("Cart not found");

            var item = cart.Items.FirstOrDefault(i => i.ProductId == productId);
            if (item == null)
                throw new InvalidOperationException("Item not found");

            if (newQuantity <= 0)
            {
                cart.Items.Remove(item);
            }
            else
            {
                item.Quantity = newQuantity;
            }
            await _context.SaveChangesAsync();
        }
    }
}
