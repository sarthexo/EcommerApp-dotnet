using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Application.Features.Products.Commands
{
    public record CreateProductCommand
    (
        [Required]
        string Name,
        string Description,
        decimal Price,
        int Stock,
        Guid CategoryId
        ):IRequest<Guid>;
}
