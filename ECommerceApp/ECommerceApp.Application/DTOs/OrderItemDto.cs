using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Application.DTOs
{
    public record OrderItemDto
    (
        Guid ProductId,
        int Quantity,
        decimal UnitPrice

    );
}
