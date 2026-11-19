using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.Features.Orders.Commands.CreateOrder;
using OnlineShop.Application.Features.Orders.Queries.GetOrderById;

namespace OnlineShop.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IMediator _mediator;
        public OrdersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById
            (Guid id, CancellationToken cancellationToken)
        {
            try
            {
                var cart = await _mediator.Send(new GetOrderByIdQuery(id), cancellationToken);
                return Ok(cart);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }


        }
        [HttpPost]
        public async Task<IActionResult> CreateOrder(Guid id , CancellationToken cancellationToken) 
        {
            try
            {
                var orderId = await _mediator.Send(new CreateOrderCommand(id), cancellationToken);
                return Ok(orderId);

            }
            catch(KeyNotFoundException) 
            {
                return NotFound();
            }

        
        }
    }
}
