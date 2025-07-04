using ECommerceApp.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Application.Features.Orders.Commands
{
  public  class DeleteOrderCommandHandler:IRequestHandler<DeleteOrderCommand,bool>
    {
        private readonly IOrderRepository _orderRepository;

        public DeleteOrderCommandHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<bool> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            var order=await _orderRepository.GetByIdAsync(request.OrderId);
            if (order == null) return false;

            await _orderRepository.DeleteAsync(order);
            return true;
        }
    }
}
