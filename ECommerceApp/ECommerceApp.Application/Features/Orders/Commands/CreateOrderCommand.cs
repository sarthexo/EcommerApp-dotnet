using ECommerceApp.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Application.Features.Orders.Commands
{
   public record CreateOrderCommand
    (
        Guid UserId,
        List<OrderItemDto> Items   
    ):IRequest<Guid>;

}
