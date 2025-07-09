using ECommerceApp.Application.DTOs;
using ECommerceApp.Application.Interfaces;
using ECommerceApp.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Application.Features.Users.Queries
{
    public class GetUsersByRoleQueryHandler : IRequestHandler<GetUsersByRoleQuery, List<UserDto>>
    {
        private readonly IUserRepository _userRepository;
        public GetUsersByRoleQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<List<UserDto>> Handle(GetUsersByRoleQuery request, CancellationToken cancellationToken)
        {
            if (!Enum.TryParse<Role>(request.RoleName,true , out var role))
            {
                throw new ArgumentException("Invalid role");
            }

            var users = await _userRepository.GetUsersByRoleAsync(role);

            return users.Select(u => new UserDto(u.Id, u.Username, u.Email, u.Role.ToString())).ToList();
        }
    }
}
