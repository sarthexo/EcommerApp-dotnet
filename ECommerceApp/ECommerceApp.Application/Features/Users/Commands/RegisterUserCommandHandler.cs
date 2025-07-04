using ECommerceApp.Application.Interfaces;
using ECommerceApp.Domain.Entities;
using ECommerceApp.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Application.Features.Users.Commands
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, Guid>
    {
        private readonly IUserRepository _userRepository;
        private readonly IAuthService _authService;

        public RegisterUserCommandHandler(IUserRepository userRepository,IAuthService authService)
        {
            _userRepository = userRepository;
            _authService = authService;

        }
        public async Task<Guid> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
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
