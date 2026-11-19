using FluentValidation;

namespace OnlineShop.Application.Features.Orders.Commands.CreateOrder
{
    public class CreateOrderCommandValidator
        : AbstractValidator<CreateOrderCommand>
    {
        public CreateOrderCommandValidator()
        {
            RuleFor(command => command.CartId)
                .NotEmpty()
                .WithMessage("Cart ID is required.");
        }
    }
}
