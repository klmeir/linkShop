using FluentValidation;
using Ordering.Application.Carts;

namespace Ordering.Api.ApiHandlers.Carts
{
    public class CartAddValidator : AbstractValidator<CartAddCommand>
    {

        public CartAddValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.CustomerId).NotEmpty();
            RuleFor(x => x.Items).NotEmpty();
        }
    }
}
