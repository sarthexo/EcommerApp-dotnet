using ECommerceApp.Application.Interfaces;
using ECommerceApp.Domain.Entities;
using ECommerceApp.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Infrastructure.Seeding
{
    public class SuperAdminSeeder : ISuperAdminSeeder
    {
        private readonly IUserRepository _userRepository;
        private readonly IAuthService _authService;

        public SuperAdminSeeder(IUserRepository userRepository,IAuthService authService)
        {
            _userRepository = userRepository;
            _authService = authService;
        }
        public async Task SeedAsync()
        {
            var email = "Admin@gmail.com";
            var password = "Admin@123";

            var existing = await _userRepository.GetByEmailAsync(email);
            if (existing != null) return;

            var user = new User
            {
                Id = Guid.NewGuid(),
                Username = "SuperAdmin",
                Email = email,
                PasswordHash = _authService.HashPassword(password),
                Role = Role.SuperAdmin,
                CreatedAt = DateTime.UtcNow

            };

            await _userRepository.AddAsync(user);

            
        }
    }
}
