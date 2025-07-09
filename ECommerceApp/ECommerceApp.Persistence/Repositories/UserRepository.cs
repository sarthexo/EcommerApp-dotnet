using ECommerceApp.Application.Interfaces;
using ECommerceApp.Domain.Entities;
using ECommerceApp.Domain.Enums;
using ECommerceApp.Infrastructure.Exceptions;
using ECommerceApp.Persistence.DbtContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;
        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteUserAsync(Guid userId)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user == null)
                throw new NotFoundException("User not found");

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return true;
            
        }

        public async Task<User?> GetByEmailAsync(string email)
        {
           // var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<User?> GetByIdAsync(Guid id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<List<User>> GetUsersByRoleAsync(Role role)
        {
            return await _context.Users
                .Where(u => u.Role == role)
                .ToListAsync();
        }

        public async Task<int> GetAdminCountAsync()
        {
            return await _context.Users.CountAsync(u => u.Role == Domain.Enums.Role.Admin);
        }

        public async Task<bool> UpdateUserAsync(Guid userId, string fullName, string email)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user == null)
                throw new NotFoundException("User Not Found");

            user.Username = fullName;
            user.Email = email;

            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return true;
            
        }

        public async Task<User?> GetByUsernameAsync(string username)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Username == username);
        }
    }
}
