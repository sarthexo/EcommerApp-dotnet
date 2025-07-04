using ECommerceApp.Application.DTOs;
using ECommerceApp.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Application.Features.Carts.Queries
{
   public  class GetCartByUserIdQueryHandler:IRequestHandler<GetCartByUserIdQuery,CartDto>
    {
        private readonly ICartRepository _cartRepository;

        public GetCartByUserIdQueryHandler(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public async Task<CartDto> Handle(GetCartByUserIdQuery request, CancellationToken cancellationToken)
        {
            var cart = await _cartRepository.GetByUserIdAsync(request.UserId);

            var dto = new CartDto(
                cart.UserId,
                cart.Items.Select(i => new CartItemDto(i.ProductId, i.ProductName, i.Quantity, i.Price)).ToList()
                );

            return dto;

    }
}
