using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Application.Features.Users.Commands
{
    public  record UpdateUserCommand(Guid UserId,string FullName,string Email):IRequest<bool>;

    
}
