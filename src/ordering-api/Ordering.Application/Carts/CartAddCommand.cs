using MediatR;
using Ordering.Domain.Entities;

namespace Ordering.Application.Carts
{
    public record CartAddCommand(Guid Id, Guid CustomerId, List<CartItem> Items) : IRequest<Cart>;
}
