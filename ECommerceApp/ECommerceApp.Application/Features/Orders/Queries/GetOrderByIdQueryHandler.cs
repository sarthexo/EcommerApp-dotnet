using AutoMapper;
using ECommerceApp.Application.DTOs;
using ECommerceApp.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Application.Features.Orders.Queries
{
   public class GetOrderByIdQueryHandler:IRequestHandler<GetOrderByIdQuery,OrderDto>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public GetOrderByIdQueryHandler(IOrderRepository orderRepository,IMapper mapper)
        {

            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<OrderDto> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetByIdAsync(request.OrderId);
            return order == null ? null : _mapper.Map<OrderDto>(order);
        }
    }
}
