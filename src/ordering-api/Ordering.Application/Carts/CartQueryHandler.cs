using MediatR;
using Ordering.Domain.Entities;
using Ordering.Infrastructure.Ports;

namespace Ordering.Application.Carts
{
    public class CartQueryHandler : IRequestHandler<CartQuery, Cart>
    {
        private readonly IRepository<Cart> _repository;

        public CartQueryHandler(IRepository<Cart> repository) =>
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));

        public async Task<Cart> Handle(CartQuery request, CancellationToken cancellationToken)
        {
            return (await _repository.GetManyAsync(filter: x => x.Id == request.Id, includeStringProperties: $"{nameof(Cart.Items)}")).FirstOrDefault();
        }
    }
}
