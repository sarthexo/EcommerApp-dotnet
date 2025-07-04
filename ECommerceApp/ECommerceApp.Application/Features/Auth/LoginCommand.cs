using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Application.Features.Auth
{
   public record LoginCommand
    (
        [Required]
        string Email,

        [Required]
        string Passowrd
   ):IRequest<string>; //returns JWT token
}
