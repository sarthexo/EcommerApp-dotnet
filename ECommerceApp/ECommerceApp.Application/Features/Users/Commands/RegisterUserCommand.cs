using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Application.Features.Users.Commands
{
   public record RegisterUserCommand(
       [Required]
       string Username,

       [Required,EmailAddress]
       string Email,

       [Required]
       string Password,

       string Role

       ) : IRequest<Guid>;
    
}
