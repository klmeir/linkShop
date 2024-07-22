using MediatR;
using Ordering.Domain.Entities;
using Ordering.Domain.Ports;
using Ordering.Infrastructure.Ports;

namespace Ordering.Application.Carts
{
    public class CartAddCommanddHandler : IRequestHandler<CartAddCommand, Cart>
    {
        private readonly IRepository<Cart> _repository;
        private readonly IUnitOfWork _unitOfWork;

        public CartAddCommanddHandler(IRepository<Cart> repository, IUnitOfWork unitOfWork)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<Cart> Handle(CartAddCommand request, CancellationToken cancellationToken)
        {
            var savedCart = await _repository.AddAsync(new Cart(request.Id, request.CustomerId, request.Items));

            return savedCart;
        }
    }
}
