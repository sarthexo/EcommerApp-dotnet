using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Application.Features.Orders.Commands
{
   public record UpdateOrderStatusCommand(Guid OrderId , string NewStatus):IRequest<bool>;

    
}
