using ECommerceApp.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Application.Features.Carts.Commands
{
    public class AddCartItemCommandHandler : IRequestHandler<AddCartItemCommand>
    {
        private readonly ICartRepository _cartRepository;

        public AddCartItemCommandHandler(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }
        public async Task<Unit> Handle(AddCartItemCommand request, CancellationToken cancellationToken)
        {
            await _cartRepository.AddItemAsync(request.UserId, request.ProductId, request.Quantity);
            return Unit.Value;
        }
    }
}
