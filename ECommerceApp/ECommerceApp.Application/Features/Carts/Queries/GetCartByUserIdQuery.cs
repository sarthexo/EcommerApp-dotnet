using ECommerceApp.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Application.Features.Carts.Queries
{
   public record GetCartByUserIdQuery(Guid UserId):IRequest<CartDto>;
    
}
