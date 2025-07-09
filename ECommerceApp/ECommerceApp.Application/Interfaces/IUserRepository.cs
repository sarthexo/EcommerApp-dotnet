using ECommerceApp.Domain.Entities;
using ECommerceApp.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Application.Interfaces
{
  public   interface IUserRepository
    {
        Task<User?> GetByEmailAsync(string email);
        Task AddAsync(User user);
        Task<User?> GetByIdAsync(Guid id);

        Task<bool> UpdateUserAsync(Guid userId, string fullName, string email);

        Task<bool> DeleteUserAsync(Guid userId);
        Task<int> GetAdminCountAsync();

        Task<List<User>> GetUsersByRoleAsync(Role role);

        Task<User?> GetByUsernameAsync(string username);

    }
}
