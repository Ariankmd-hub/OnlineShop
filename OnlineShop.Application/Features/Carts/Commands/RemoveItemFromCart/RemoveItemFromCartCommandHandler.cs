using MediatR;
using OnlineShop.Domain.Entities;
using OnlineShop.Domain.IRepository;

namespace OnlineShop.Application.Features.Carts.Commands.RemoveItemFromCart
{
    public class RemoveItemFromCartCommandHandler :
        IRequestHandler<RemoveItemFromCartCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenericRepository<CartItem> _cartItemRepository;
        public RemoveItemFromCartCommandHandler(
            IUnitOfWork unitOfWork, IGenericRepository<CartItem> cartItemRepository)
        {
            _cartItemRepository = cartItemRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> Handle(RemoveItemFromCartCommand request, CancellationToken cancellationToken)
        {
            CartItem? cartItem = await _cartItemRepository.GetByIdAsync(request.Id, cancellationToken);
            if (cartItem == null) 
            {
                throw new KeyNotFoundException($"There is no CartItem with {request.Id} Id");
            }
            _cartItemRepository.Remove(cartItem);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
