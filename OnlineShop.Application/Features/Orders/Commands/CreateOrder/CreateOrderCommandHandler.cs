using MediatR;
using OnlineShop.Domain.Entities;
using OnlineShop.Domain.IRepository;

namespace OnlineShop.Application.Features.Orders.Commands.CreateOrder
{
    public class CreateOrderCommandHandler :
        IRequestHandler<CreateOrderCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;
        
        private readonly ICartItemRepository _cartItemRepository;

        private readonly IGenericRepository<Order> _orderRepository;
        private readonly IGenericRepository<OrderItem> _orderItemRepository;

        private readonly IGenericRepository<Product> _productRepository;

        private readonly IGenericRepository<Cart> _cartRepository;
        public CreateOrderCommandHandler
            (IUnitOfWork unitOfWork, IGenericRepository<Cart> cartRepository,
            ICartItemRepository cartItemRepository, IGenericRepository<Order> orderRepository,
            IGenericRepository<OrderItem> orderItemRepository,
            IGenericRepository<Product> productRepository)
        {
            _cartRepository = cartRepository;
            _unitOfWork = unitOfWork;
            _cartItemRepository = cartItemRepository;
            _orderItemRepository = orderItemRepository;
            _orderRepository = orderRepository;
            _productRepository = productRepository;
        }
        
        public async Task<Guid> Handle
            (CreateOrderCommand request, CancellationToken cancellationToken)
        {
            Cart? cart = await _cartRepository.GetByIdAsync(request.CartId,cancellationToken);
            if(cart == null) 
            {
                throw new KeyNotFoundException($"There is Cart with {request.CartId} Id");
            }
            var cartItems = await _cartItemRepository.GetByCartIdAsync(request.CartId,cancellationToken);

            // why we created here?  to give OrderId to our OrderItems
            Order order = new Order
            {
                TotalAmount = 0
            };
            if (!cartItems.Any())
            {
                throw new InvalidOperationException("Cannot create an order from an empty cart.");
            }


            foreach (var cartItem in cartItems) 
            {
                Product? Product = 
                    await _productRepository.GetByIdAsync(cartItem.ProductId,cancellationToken);
                if (Product == null) 
                {
                    throw new KeyNotFoundException($"There is Product with {cartItem.ProductId} Id");
                }

                OrderItem orderItem = new OrderItem()
                {
                    Quantity = cartItem.Quantity,
                    UnitPrice = Product.Price,
                    OrderId = order.Id,
                    ProductId = cartItem.ProductId,

                };
                order.TotalAmount += (orderItem.UnitPrice * orderItem.Quantity);
                await _orderItemRepository.AddAsync(orderItem, cancellationToken);
                _cartItemRepository.Remove(cartItem);
                
            }
            await _orderRepository.AddAsync(order, cancellationToken);
            

            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return order.Id;

           
        }
    }
}
