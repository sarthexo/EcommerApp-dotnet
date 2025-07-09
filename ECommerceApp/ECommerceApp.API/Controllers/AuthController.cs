using ECommerceApp.Application.DTOs;
using ECommerceApp.Application.Features.Auth;
using ECommerceApp.Application.Features.Users.Commands;
using ECommerceApp.Application.Features.Users.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto dto)
        {
            var command = new RegisterUserCommand(dto.FullName, dto.Email, dto.Password, dto.Role);
            var userId = await _mediator.Send(command);
            return Ok(new { UserId = userId });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto dto)
        {
            var command = new LoginCommand(dto.Email, dto.Password);
            var token = await _mediator.Send(command);
            return Ok(new { Token = token });
        }


        [Authorize(Roles = "Admin")]
        [HttpGet("users-by-role/{roleName}")]
        public async Task<IActionResult> GetUsersByRole(string roleName)
        {
            var query = new GetUsersByRoleQuery(roleName);
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}
