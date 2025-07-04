using ECommerceApp.Application.Interfaces;
using ECommerceApp.Domain.Entities;
using ECommerceApp.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Application.Features.Orders.Commands
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Guid>
    {
        IOrderRepository _orderRepository;
        public CreateOrderCommandHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public async Task<Guid> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var orderId = Guid.NewGuid();

            var order = new Order
            {
                Id = orderId,
                UserId = request.UserId,
                OrderDate = DateTime.UtcNow,
                status = OrderStatus.Pending,
                TotalAmount = request.Items.Sum(i => i.Quantity * i.UnitPrice)
            };

            var items = request.Items.Select(i => new OrderItem
            {
                Id = Guid.NewGuid(),
                OrderId = orderId,
                ProductId = i.ProductId,
                Quantity = i.Quantity,
                UnitPrice = i.UnitPrice
            }).ToList();

            await _orderRepository.CreateOrderAsync(order, items);
            return orderId;
        }
    }
}
