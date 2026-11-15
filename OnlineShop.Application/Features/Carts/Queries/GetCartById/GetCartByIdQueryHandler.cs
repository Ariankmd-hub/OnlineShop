using MediatR;
using OnlineShop.Domain.Entities;
using OnlineShop.Domain.IRepository;

namespace OnlineShop.Application.Features.Carts.Queries.GetCartById
{
    public class GetCartByIdQueryHandler :
        IRequestHandler<GetCartByIdQuery, Cart>
    {
        private readonly IGenericRepository<Cart> _cartRepository;
        public GetCartByIdQueryHandler
            (IGenericRepository<Cart> cartRepository)
        {
            _cartRepository = cartRepository;
        }
        public async Task<Cart> Handle(GetCartByIdQuery request, CancellationToken cancellationToken)
        {
            Cart? cart = await _cartRepository.GetByIdAsync(request.CartId,cancellationToken);
            if (cart == null) 
            {
                throw new KeyNotFoundException($"couldn't find Cart with {request.CartId} Id");
            }

            return cart;
            
        }
    }
}
