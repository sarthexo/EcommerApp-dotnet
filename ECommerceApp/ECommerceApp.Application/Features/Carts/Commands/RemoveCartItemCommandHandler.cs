using ECommerceApp.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Application.Features.Carts.Commands
{
    public class RemoveCartItemCommandHandler : IRequestHandler<RemoveCartItemCommand>
    {
        private readonly ICartRepository _cartRepository;

        public RemoveCartItemCommandHandler(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }
        public async Task<Unit> Handle(RemoveCartItemCommand request, CancellationToken cancellationToken)
        {
            await _cartRepository.RemoveItemAsync(request.UserId, request.ProductId);
            return Unit.Value;
        }
    }
}
