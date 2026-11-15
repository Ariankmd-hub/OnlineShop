using MediatR;
using OnlineShop.Domain.Entities;
using OnlineShop.Domain.IRepository;

namespace OnlineShop.Application.Features.Carts.Commands.AddItemToCart
{
    public class AddItemToCartCommandHandler :
        IRequestHandler<AddItemToCartCommand, Guid>
    {
        private readonly ICartItemRepository  _cartItemRepository;

        private readonly IGenericRepository<Product> _productRepository;

        private readonly IGenericRepository<Cart> _cartRepository;
        private readonly IUnitOfWork _unitOfWork;
        public AddItemToCartCommandHandler
            (ICartItemRepository cartItemRepository, IUnitOfWork unitOfWork,
            IGenericRepository<Product> productRepository, IGenericRepository<Cart> cartRepository)
        {
            _cartItemRepository = cartItemRepository;
            _unitOfWork = unitOfWork;
            _productRepository = productRepository;
            _cartRepository = cartRepository;
        }



        public async Task<Guid> 
            Handle(AddItemToCartCommand request, CancellationToken cancellationToken)
        {
            Product? product = 
                await _productRepository.GetByIdAsync(request.ProductId, cancellationToken);
            
            // Business Logic
            
            if (product == null) 
            {
                throw new KeyNotFoundException
                    ($"Couldn't find a Product with {request.ProductId} Id");
            }

            Cart cart;
            // if Cart ID was null 
            if (request.CartId == null) 
            {
                 cart = new Cart ();
                await _cartRepository.AddAsync(cart, cancellationToken);
            }
            // if there was Cart ID
            else 
            {
                // Check if it's Correct 
                
                Cart? existingCart = 
                    await _cartRepository.GetByIdAsync(request.CartId.Value, cancellationToken);
                if (existingCart == null) 
                {
                    throw new KeyNotFoundException($"Cart {request.CartId} not found");
                }
                // if it was correct 
                cart = existingCart;
            
            }
            // check if CartItem is Already in our Cart . 
            CartItem? existingItem = await _cartItemRepository.
                GetByCartAndProductAsync(cart.Id, request.ProductId, cancellationToken);
            if (existingItem == null) 
            {
                CartItem cartItem = new CartItem()
                {
                    Quantity = request.Quantity,
                    CartId = cart.Id,
                    ProductId = request.ProductId
                };
                await _cartItemRepository.AddAsync(cartItem, cancellationToken);

            }
            else 
            {
                existingItem.Quantity += request.Quantity;
            }
            
           
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return cart.Id;
        }
    }
}
