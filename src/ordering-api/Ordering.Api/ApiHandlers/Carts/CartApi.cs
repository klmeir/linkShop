using MediatR;
using Ordering.Api.Filters;
using Ordering.Application.Carts;
using Ordering.Domain.Entities;

namespace Ordering.Api.ApiHandlers.Carts
{
    public static class CartApi
    {
        public static RouteGroupBuilder MapCarts(this IEndpointRouteBuilder routeHandler)
        {
            routeHandler.MapGet("/", async (IMediator mediator) =>
            {
                return Results.Ok(await mediator.Send(new CartsQuery()));
            })            
            .Produces(StatusCodes.Status200OK, typeof(Cart));

            routeHandler.MapGet("/{id}", async (IMediator mediator, Guid id) =>
            {
                var cart = await mediator.Send(new CartQuery(id));
                return cart is null ? Results.NotFound() : Results.Ok(cart);
            })
            .WithName("GetCart")
            .Produces(StatusCodes.Status200OK, typeof(Cart))
            .Produces(StatusCodes.Status404NotFound);      

            routeHandler.MapPost("/", async (IMediator mediator, [Validate] CartAddCommand cart) =>
            {                                
                var savedCart = await mediator.Send(cart);
                return Results.CreatedAtRoute("GetCart", new { id = savedCart.Id }, savedCart);                
            })
            .Produces(StatusCodes.Status201Created, typeof(Cart))
            .Produces(StatusCodes.Status400BadRequest);

            return (RouteGroupBuilder)routeHandler;
        }
    }
}
