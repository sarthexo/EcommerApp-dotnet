using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Application.DTOs
{
   public  record RegisterDto(string FullName, string Email, string Password, string Role);
    
}
