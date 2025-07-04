using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Application.DTOs
{
   public  record CartItemDto(Guid ProductId,string ProductName,int Quantity,decimal Price);
   
    
}
