using MediatR;
using Ordering.Domain.Entities;

namespace Ordering.Application.Carts
{
    public record CartsQuery() : IRequest<List<Cart>>;
}
