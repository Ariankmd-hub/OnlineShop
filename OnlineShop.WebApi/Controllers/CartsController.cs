using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.Features.Carts.Commands.AddItemToCart;
using OnlineShop.Application.Features.Carts.Commands.ClearCart;
using OnlineShop.Application.Features.Carts.Commands.RemoveItemFromCart;
using OnlineShop.Application.Features.Carts.Queries.GetCartById;


namespace OnlineShop.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CartsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CartsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById
            (Guid id,CancellationToken cancellationToken) 
        {
            try
            {
                var cart = await _mediator.Send(new GetCartByIdQuery(id), cancellationToken);
                return Ok(cart);
            }
            catch (KeyNotFoundException) 
            {
                return NotFound();
            }


        }
        [HttpPost]
        public async Task<IActionResult> AddItem
            ([FromBody] AddItemToCartCommand command,CancellationToken cancellationToken) 
        {
            try
            {
                await _mediator.Send(command, cancellationToken);
                return Ok();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }
        
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> RemoveItem
            (Guid id,CancellationToken cancellationToken) 
        {
            try
            {
                await _mediator.Send(new RemoveItemFromCartCommand(id), cancellationToken);
                return NoContent();

            }
            catch (KeyNotFoundException) { return NotFound(); }
        }
        [HttpDelete("{id:guid}/clear")]
        public async Task<IActionResult> ClearCart(Guid id, CancellationToken cancellationToken)
        {
            try
            {
                await _mediator.Send(new ClearCartCommand(id), cancellationToken);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }



    }
}
