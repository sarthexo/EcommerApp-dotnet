using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Auth - Logout (optional, clears token client-side or invalidates refresh tokens)
namespace ECommerceApp.Application.Features.Auth
{
    public class LogoutCommandHandler : IRequestHandler<LogoutCommand, Unit>
    {
        public Task<Unit> Handle(LogoutCommand request, CancellationToken cancellationToken)
        {
            // Typically token is removed on client side; if tracking tokens server-side, invalidate here.
            return Task.FromResult(Unit.Value);
        }
    }
}
