using ECommerceApp.Application.DTOs;
using ECommerceApp.Application.Features.Categories.Queries;
using ECommerceApp.Application.Features.Payments.Commands;
using ECommerceApp.Application.Features.Products;
using ECommerceApp.Application.Features.Products.Commands;
using ECommerceApp.Application.Features.Products.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetProductById(Guid id)
        {
            var product = await _mediator.Send(new GetProductByIdQuery(id));
            return Ok(product);
        }

        [HttpGet]
        public async Task<ActionResult<List<ProductDto>>> GetAllProducts()
        {
            var products = await _mediator.Send(new GetAllProductsQuery());
            return Ok(products);
        }

        [Authorize(Roles ="Admin,SuperAdmin")]
        [HttpPost]        
        public async Task<ActionResult<Guid>> CreateProduct([FromBody] CreateProductDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var command = new CreateProductCommand(
                dto.Name,
                dto.Description ?? string.Empty,
                dto.Price,
                dto.Stock,
                dto.CategoryId
                );

            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetProductById), new { id }, id);
        }

        [Authorize(Roles ="Admin,SuperAdmin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(Guid id, [FromBody] UpdateProductDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var command = new UpdateProductCommand(
                id,
                dto.Name,
                dto.Description ?? string.Empty,
                dto.Price,
                dto.Stock,
                dto.CategoryId
                );

            await _mediator.Send(command);
            return NoContent();
        }


        [Authorize(Roles ="Admin,SuperAdmin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(Guid id)
        {
            await _mediator.Send(new DeleteProductCommand(id));
            return NoContent();
        }
    }
}
