using MediatR;
using OnlineShop.Domain.Entities;
using OnlineShop.Domain.IRepository;

namespace OnlineShop.Application.Features.Orders.Queries.GetOrderById
{
    public class GetOrderByIdQueryHandler : 
        IRequestHandler<GetOrderByIdQuery, Order>
    {
        private readonly IGenericRepository<Order> _orderRepository;

        public GetOrderByIdQueryHandler(IGenericRepository<Order> orderRepository)
        {
         _orderRepository = orderRepository;   
        }
        public async Task<Order> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            Order? order = await _orderRepository.GetByIdAsync(request.OrderId, cancellationToken);
            if (order == null) 
            {
                throw new KeyNotFoundException($"There is no Order with {request.OrderId} Id");
            }
            return order;

        
        }
    }
}
