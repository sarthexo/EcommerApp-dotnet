using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Application.DTOs
{
   public record UserDto
    (
        Guid Id,
        string User,
        string Email,
        string Role
    );
}
