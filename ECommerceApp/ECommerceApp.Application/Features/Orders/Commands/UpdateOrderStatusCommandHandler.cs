using ECommerceApp.Application.Interfaces;
using ECommerceApp.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Application.Features.Orders.Commands
{
   public  class UpdateOrderStatusCommandHandler:IRequestHandler<UpdateOrderStatusCommand,bool>
    {
        private readonly IOrderRepository _orderRepository;

        public UpdateOrderStatusCommandHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<bool> Handle(UpdateOrderStatusCommand request, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetByIdAsync(request.OrderId);
            if (order == null) return false;



            if (!Enum.TryParse<OrderStatus>(request.NewStatus, true, out var status))
                return false;

            order.status = status;

            await _orderRepository.UpdateAsync(order);
            return true;
        }
    }
}
