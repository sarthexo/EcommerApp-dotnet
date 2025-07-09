using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Application.Features.Carts.Commands
{
   public  record UpdateCartItemQuantityCommand(Guid UserId, Guid ProductId , int NewQuantity):IRequest<Unit>;
    
}
