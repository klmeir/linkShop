using MediatR;
using Ordering.Domain.Entities;
using Ordering.Infrastructure.Ports;

namespace Ordering.Application.Carts
{
    public class CartsQueryHandler : IRequestHandler<CartsQuery, List<Cart>>
    {
        private readonly IRepository<Cart> _repository;

        public CartsQueryHandler(IRepository<Cart> repository) =>
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));

        public async Task<List<Cart>> Handle(CartsQuery request, CancellationToken cancellationToken)
        {
            return (await _repository.GetManyAsync(includeStringProperties: $"{nameof(Cart.Items)}")).ToList();
        }
    }
}
