using ECommerceApp.Application.Interfaces;
using ECommerceApp.Domain.Entities;
using ECommerceApp.Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Application.Features.Users.Commands
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, Guid>
    {
        private readonly IUserRepository _userRepository;
        private readonly IAuthService _authService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public RegisterUserCommandHandler(IUserRepository userRepository,IAuthService authService,IHttpContextAccessor httpContextAccessor)
        {
            _userRepository = userRepository;
            _authService = authService;
            _httpContextAccessor = httpContextAccessor;

        }
        public async Task<Guid> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            //checking for valid role
            if (!Enum.TryParse<Role>(request.Role,true, out var role))
            {
                throw new ArgumentException("Invalid role specified");
            }

            //checking if email already exist
            var existingUserByEmail = await _userRepository.GetByEmailAsync(request.Email);
            if (existingUserByEmail != null)
                throw new InvalidOperationException("A User with this email already exists.");

            //checking if username already exist
            //var existingUserName = await _userRepository.GetByUsernameAsync(request.Username);
            //if (existingUserName != null)
            //    throw new InvalidOperationException("A User with this userName alreay exist");

           

            // Prevent public Registration of Admin // Handle Admin logic

            if (role ==Role.Admin)
            {
                var currentRoleUserRole = _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.Role)?.Value;
                if (!string.Equals(currentRoleUserRole, Role.SuperAdmin.ToString(), StringComparison.OrdinalIgnoreCase))
                    throw new UnauthorizedAccessException("Only superadmin can create a admin");
                
                var AdminCount = await _userRepository.GetAdminCountAsync();
                if (AdminCount>2)
                    throw new UnauthorizedAccessException(" 3 admins allowed already exist");
                var AddAdmin = new User
                {
                    Id = Guid.NewGuid(),
                    Username = request.Username,
                    Email = request.Email,
                    PasswordHash = _authService.HashPassword(request.Password),
                    Role = Role.Admin,
                    CreatedAt = DateTime.UtcNow
                };
                await _userRepository.AddAsync(AddAdmin);
                return AddAdmin.Id;
            }

            //Regular user creation
            var user = new User
            {
                Id = Guid.NewGuid(),
                Username =request.Username,
                Email =request.Email,
                PasswordHash=_authService.HashPassword(request.Password),
                Role=Role.User,
                CreatedAt=DateTime.UtcNow
            };

            await _userRepository.AddAsync(user);
            return user.Id;
        }
    }
}
