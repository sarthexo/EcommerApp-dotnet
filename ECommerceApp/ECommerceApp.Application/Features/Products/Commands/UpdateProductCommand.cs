using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Application.Features.Products.Commands
{
   public record UpdateProductCommand
    (
       Guid Id,
       [Required] string Name,
       string Description,
       decimal Price,
       int Stock,
       Guid CategoryId
       ):IRequest;
}
