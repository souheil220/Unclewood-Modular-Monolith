using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Unclewood.Modules.Ingredients.Application.Commands.CreateIngredient;

namespace Unclewood.Modules.Ingredients.Presentation.Ingredients;

internal static class CreateIngredient
{
    public static void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("ingredients", async (CreateIngridientRequest request, ISender mediator) =>
        {
            var command = new CreateIngredientCommand(
                request.Name,
                //request.DisponibleIn,
                request.PriceValue,
                request.PriceCurrency
            );
            var createIngredientResult = await mediator.Send(command);
            if (createIngredientResult.IsFailure)
            {
                return Results.BadRequest(createIngredientResult.Error);
            }

            return Results.Ok(createIngredientResult.Value);
        }).WithTags(Tags.Ingredients);
    }
}