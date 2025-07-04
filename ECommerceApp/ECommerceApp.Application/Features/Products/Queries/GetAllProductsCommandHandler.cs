using ECommerceApp.Application.DTOs;
using ECommerceApp.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Application.Features.Products.Queries
{
    public class GetAllProductsCommandHandler : IRequestHandler<GetAllProductsQuery, List<ProductDto>>
    {
        private readonly IProductRepository _productRepository;
        public GetAllProductsCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<List<ProductDto>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await _productRepository.GetAllAsync();

            return products.Select(p => new ProductDto(
                p.Id, p.Name, p.Description, p.Price, p.Stock, p.CategoryId)).ToList();
        }
        
    }
}
