using Catalog.Application.Products;
using Catalog.Domain.Entities;
using MediatR;

namespace Catalog.Api.ApiHandlers.Products
{
    public static class ProductApi
    {
        public static RouteGroupBuilder MapProducts(this IEndpointRouteBuilder routeHandler)
        {           
            routeHandler.MapGet("/", async (IMediator mediator) =>
            {
                return Results.Ok(await mediator.Send(new ProductsQuery()));
            })            
            .Produces(StatusCodes.Status200OK, typeof(List<Product>)); 

            return (RouteGroupBuilder)routeHandler;
        }
    }
}
