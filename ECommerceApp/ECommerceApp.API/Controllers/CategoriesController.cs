using ECommerceApp.Application.DTOs;
using ECommerceApp.Application.Features.Categories;
using ECommerceApp.Application.Features.Categories.Commands;
using ECommerceApp.Application.Features.Categories.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoriesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<CategoryDto>>> GetAll()
        {
            var result = await _mediator.Send(new GetAllCategoriesQuery());
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryDto>> GetById(Guid id)
        {
            var result = await _mediator.Send(new GetCategoryByIdQuery(id));
            if (result == null)
                return NotFound("Category not found");

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] string command)
        {
            if (string.IsNullOrWhiteSpace(command))
            {
                return BadRequest("Name is required");
            }

            var categoryId = await _mediator.Send(new CreateCategoryCommand(command));
            return Ok(categoryId);
        }

        [HttpPut]
        public async Task<IActionResult> Update(Guid id, [FromBody] string command)
        {
   

            var success = await _mediator.Send(new UpdateCategoryCommand(id,command));
            if (!success)
            {
                return NotFound("Category not found");
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var success = await _mediator.Send(new DeleteCategoryCommand(id));
            if (!success) return NotFound("Category not found");
            return NoContent();
        }
    }
}
