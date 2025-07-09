using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Application.Interfaces.Auth
{
   public  interface ITokenService
    {
        string GenerateToken(Guid userId, string email, string role);
    }
}
