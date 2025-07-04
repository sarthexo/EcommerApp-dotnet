using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Application.DTOs
{
  public record OrderDto
    (
        Guid Id,
        Guid UserId,
        DateTime OrderDate,
        decimal TotalAmount,
        string Status,
        List<OrderItemDto> items

    );
}
