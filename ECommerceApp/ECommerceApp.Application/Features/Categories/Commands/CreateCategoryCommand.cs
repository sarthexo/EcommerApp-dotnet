using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Application.Features.Categories
{
   public record CreateCategoryCommand(string name):IRequest<Guid>;
    
}
