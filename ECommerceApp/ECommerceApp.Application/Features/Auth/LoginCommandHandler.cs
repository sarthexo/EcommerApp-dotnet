using ECommerceApp.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Application.Features.Auth
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, string>
    {
        private readonly IUserRepository _userRepository;
        private readonly IAuthService _authService;

        public LoginCommandHandler(IUserRepository userRepository,IAuthService authService)
        {
            _userRepository = userRepository;
            _authService = authService;
        }
        public async Task<string> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByEmailAsync(request.Email)
                        ?? throw new UnauthorizedAccessException("Invalid credentials");

            if (!_authService.VerifyPassword(request.Passowrd, user.PasswordHash))
                throw new UnauthorizedAccessException("Invalid credentials");

            return _authService.GenerateJwtToken(user.Id, user.Username, user.Role.ToString());
                
            
        }
    }
}
