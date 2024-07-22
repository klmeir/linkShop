using Catalog.Domain.Entities;
using MediatR;
using Catalog.Infrastructure.Ports;

namespace Catalog.Application.Products
{
    public class ProductsQueryHandler : IRequestHandler<ProductsQuery, List<Product>>
    {
        private readonly IRepository<Product> _repository;

        public ProductsQueryHandler(IRepository<Product> repository) =>
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));


        public async Task<List<Product>> Handle(ProductsQuery request, CancellationToken cancellationToken)
        {
            return (await _repository.GetManyAsync(includeStringProperties: $"{nameof(Product.ProductType)},{nameof(Product.ProductBrand)}")).ToList();
        }
    }
}
