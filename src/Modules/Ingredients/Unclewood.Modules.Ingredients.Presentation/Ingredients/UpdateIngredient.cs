using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Unclewood.Modules.Ingredients.Application.Commands.UpdateIngredient;

namespace Unclewood.Modules.Ingredients.Presentation.Ingredients;

public static class UpdateIngredient
{
    public static void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPatch("ingredients/{id:guid}", async (UpdateIngredientCommand ingredientCommand, 
            [FromRoute] Guid id, 
            ISender mediator,
            CancellationToken cancellationToken) =>
        {
            var command = ingredientCommand with { Id = id };
            var response = await mediator.Send(command,cancellationToken);

            if (response.IsFailure)
            {
                return Results.BadRequest(response.Error);
            }
            return Results.Ok(response.Value);
        }).WithTags(Tags.Ingredients);;
    }
}