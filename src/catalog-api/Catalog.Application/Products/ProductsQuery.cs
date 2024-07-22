using Catalog.Domain.Entities;
using MediatR;

namespace Catalog.Application.Products
{
    public record ProductsQuery() : IRequest<List<Product>>;
}
