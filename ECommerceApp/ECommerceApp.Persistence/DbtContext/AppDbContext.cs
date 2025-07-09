using ECommerceApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Persistence.DbtContext
{
   public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<User> Users => Set<User>();
        public DbSet<Product> Products => Set<Product>();
        public DbSet<Category> Categories => Set<Category>();
        public DbSet<Order> Orders => Set<Order>();
        public DbSet<OrderItem> OrderItems => Set<OrderItem>();
        public DbSet<Cart> Carts => Set<Cart>();
        public DbSet<Payment> Payments => Set<Payment>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //composite key for Order Item
            modelBuilder.Entity<OrderItem>()
                .HasKey(oi => new { oi.OrderId, oi.ProductId });

            //Relationships
            modelBuilder.Entity<Order>()
              .HasMany(o => o.OrderItems)
              .WithOne()
              .HasForeignKey(oi => oi.OrderId);

            modelBuilder.Entity<Order>()
                .Property(o => o.TotalAmount)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Payment>()
                .Property(p => p.Amount)
                .HasColumnType("decimal(18,2)");


            modelBuilder.Entity<Cart>()
                .OwnsMany(c => c.Items, a =>
                {
                    a.WithOwner().HasForeignKey("CartId");
                    a.HasKey("CartId", "ProductId");
                    a.Property(ci => ci.Price).HasColumnType("decimal(18,2)");
                });

            base.OnModelCreating(modelBuilder);
        }

        
    }
}
