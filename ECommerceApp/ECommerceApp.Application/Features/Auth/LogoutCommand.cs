using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Application.Features.Auth
{
 public  record LogoutCommand(Guid UserId):IRequest<Unit>;
    
}
