using ECommerceApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Application.Interfaces
{
   public interface IAuthService
    {
        string HashPassword(string password);
        bool VerifyPassword(string password, string passwordHash);
        string GenerateJwtToken(Guid userId, string username, string role);
    }
}
