using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.Features.Categories.Commands.CreateCategory;
using OnlineShop.Application.Features.Categories.Commands.DeleteCategory;
using OnlineShop.Application.Features.Categories.Commands.UpdateCategory;
using OnlineShop.Application.Features.Categories.Queries.GetAllCategories;
using OnlineShop.Application.Features.Categories.Queries.GetCategoryById;


namespace OnlineShop.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CategoriesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            IEnumerable<GetAllCategoriesResponse> categories =
                await _mediator.Send(new GetAllCategoriesQuery(), cancellationToken);
            return Ok(categories);

        }
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById
            (Guid id, CancellationToken cancellationToken)
        {
            var category = await _mediator.Send(new GetCategoryByIdQuery(id), cancellationToken);
            if (category == null) { return NotFound(); }
            return Ok(category);
        }
        
        [HttpPost]
        public async Task<IActionResult> Create
            ([FromBody] CreateCategoryCommand command , CancellationToken cancellationToken) 
        {
            Guid categoryId = await _mediator.Send(command, cancellationToken);
            return CreatedAtAction(nameof(GetById), new { id = categoryId });
        }
        [HttpPut]
        public async Task<IActionResult> Update
            (
            [FromBody] UpdateCategoryCommand command , CancellationToken cancellationToken)
        {
            try
            {
                await _mediator.Send(command, cancellationToken);
                return NoContent();
            }
            catch (KeyNotFoundException) 
            {
                return NotFound();
            }
            
        }
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete
            (Guid id ,CancellationToken cancellationToken) 
        {
            try
            {
              await _mediator.Send(new DeleteCategoryCommand(id), cancellationToken);
                return NoContent();

            }
            catch (KeyNotFoundException) 
            {
                return NotFound();
            }
        }
    }
}
