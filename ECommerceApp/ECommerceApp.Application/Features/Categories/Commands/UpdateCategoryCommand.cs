using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Application.Features.Categories.Commands
{
    public  record UpdateCategoryCommand(Guid Id,string Name):IRequest<bool>;
    
    
}
