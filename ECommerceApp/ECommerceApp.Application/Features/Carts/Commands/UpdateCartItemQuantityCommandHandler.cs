using ECommerceApp.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Application.Features.Carts.Commands
{
    public class UpdateCartItemQuantityCommandHandler:IRequestHandler<UpdateCartItemQuantityCommand, Unit>
    {
        private readonly ICartRepository _cartRepository;

        public UpdateCartItemQuantityCommandHandler(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public async Task<Unit> Handle(UpdateCartItemQuantityCommand request, CancellationToken cancellationToken)
        {
            await _cartRepository.UpdateQuantityAsync(request.UserId, request.ProductId, request.NewQuantity);
            return Unit.Value;
        }
    }
}
