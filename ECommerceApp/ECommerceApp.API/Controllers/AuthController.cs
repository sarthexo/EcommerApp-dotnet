using ECommerceApp.Application.DTOs;
using ECommerceApp.Application.Features.Auth;
using ECommerceApp.Application.Features.Users.Commands;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

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
    }
}
