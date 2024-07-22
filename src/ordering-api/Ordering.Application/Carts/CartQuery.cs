using MediatR;
using Ordering.Domain.Entities;

namespace Ordering.Application.Carts
{
    public record CartQuery(Guid Id) : IRequest<Cart>;
}
