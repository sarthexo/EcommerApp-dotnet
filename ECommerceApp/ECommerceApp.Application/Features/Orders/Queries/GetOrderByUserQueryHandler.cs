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
   public class GetOrderByUserQueryHandler:IRequestHandler<GetOrderByUserQuery,List<OrderDto>>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;
        public GetOrderByUserQueryHandler(IOrderRepository orderRepository,IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<List<OrderDto>> Handle(GetOrderByUserQuery request, CancellationToken cancellationToken)
        {
            var orders = await _orderRepository.GetByUserIdAsync(request.UserId);
            return _mapper.Map<List<OrderDto>>(orders);
        }
    }
}
