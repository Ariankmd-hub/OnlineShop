using MediatR;
using OnlineShop.Domain.Entities;
using OnlineShop.Domain.IRepository;

namespace OnlineShop.Application.Features.Carts.Commands.ClearCart
{
    public class ClearCartCommandHandler :
        IRequestHandler<ClearCartCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICartItemRepository _cartItemRepository;

        private readonly IGenericRepository<Cart> _cartRepository;
        public ClearCartCommandHandler(
            IUnitOfWork unitOfWork, IGenericRepository<Cart> cartRepository,
            ICartItemRepository cartItemRepository)
        {
            _cartRepository = cartRepository;
            _unitOfWork = unitOfWork;
            _cartItemRepository = cartItemRepository;
        }
        
        public async Task<bool> Handle(ClearCartCommand request, CancellationToken cancellationToken)
        {
            Cart? cart = await _cartRepository.GetByIdAsync(request.CartId,cancellationToken);
            if (cart == null) 
            {
                throw new KeyNotFoundException($"There is no Cart with {request.CartId} Id ");
            }
            var cartItems =  await _cartItemRepository.GetByCartIdAsync(request.CartId,cancellationToken);
            foreach (var cartItem in cartItems) 
            {
                _cartItemRepository.Remove(cartItem);
            }
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
