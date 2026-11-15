using MediatR;
using OnlineShop.Domain.Entities;

namespace OnlineShop.Application.Features.Orders.Queries.GetOrderById
{
    public record class GetOrderByIdQuery
        (
        Guid OrderId
        ) : IRequest<Order>
    {
    }
}
