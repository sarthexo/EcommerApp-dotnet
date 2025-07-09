using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Application.Features.Carts.Commands
{
    public record ClearCartCommand(Guid UserId):IRequest<Unit>;
    
}
