using FluentValidation;

namespace OnlineShop.Application.Features.Carts.Commands.AddItemToCart
{
    public class AddItemToCartCommandValidator
        : AbstractValidator<AddItemToCartCommand>
    {
        public AddItemToCartCommandValidator()
        {
            RuleFor(command => command.CartId)
                .NotEmpty()
                .WithMessage("CartId is required.");

            RuleFor(command => command.ProductId)
                .NotEmpty()
                .WithMessage("ProductId is required.");

            RuleFor(command => command.Quantity)
                .GreaterThan(0)
                .WithMessage("Quantity must be greater than zero.");
        }
    }
}
