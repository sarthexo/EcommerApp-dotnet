using ECommerceApp.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Application.Features.Orders.Queries
{
   public record GetOrderByUserQuery(Guid UserId):IRequest<List<OrderDto>>;
    
}
