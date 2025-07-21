using ECommerceApp.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Application.Features.Products.Queries
{
   public record GetProductByIdQuery(Guid Id):IRequest<ProductDto>;
    
}
