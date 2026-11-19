using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.Features.Products.Commands.CreateProduct;
using OnlineShop.Application.Features.Products.Commands.DeleteProduct;
using OnlineShop.Application.Features.Products.Commands.UpdateProduct;
using OnlineShop.Application.Features.Products.Queries.GetAllProducts;
using OnlineShop.Application.Features.Products.Queries.GetProductById;
using OnlineShop.Domain.Entities;


namespace OnlineShop.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        // TO SEND REQUEST TO OUR HANDELER. 
        private readonly IMediator _mediator;
        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            IEnumerable<GetAllProductsResponse> products =
                await _mediator.Send(new GetAllProductsQuery(), cancellationToken);
            return Ok(products);
        }
        
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById
            (Guid id, CancellationToken cancellationToken)
        {
            GetProductByIdResponse? product =
                await _mediator.Send(new GetProductByIdQuery(id), cancellationToken);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);

        }

        [HttpPost]
        public async Task<IActionResult> Create(
            [FromBody] CreateProductCommand command,
            CancellationToken cancellationToken)
        {
            Guid productId = await _mediator.Send(
                command,
                cancellationToken);
            return CreatedAtAction(nameof(GetById), new { id = productId });
        }

        [HttpPut]
        public async Task<IActionResult> Update
            ([FromBody] UpdateProductCommand command, CancellationToken cancellationToken)
        {
            try 
            {
                Guid productId = await _mediator.Send(command, cancellationToken);
                return NoContent();

            }
            catch (KeyNotFoundException) 
            {
                return NotFound();
            }
           

        }
        [HttpDelete("{id:guid}")]
        public async  Task<IActionResult> Delete(Guid id,CancellationToken cancellationToken) 
        {
            try
            {
                bool isDeleted = await _mediator.Send(new DeleteProductCommand(id), cancellationToken);
                return NoContent();
            }
            catch (KeyNotFoundException) 
            {
                return NotFound();
            }
    
        }
       


    }
}
