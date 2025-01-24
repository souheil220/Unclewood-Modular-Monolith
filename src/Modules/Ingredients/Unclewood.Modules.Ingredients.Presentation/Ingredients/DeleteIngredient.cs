using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Routing;
using Unclewood.Modules.Ingredients.Application.Commands.DeleteIngredient;

namespace Unclewood.Modules.Ingredients.Presentation.Ingredients;

public static class DeleteIngredient
{
    public static void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapDelete("ingredients/{id:guid}", async (
            Guid ingredientId, 
            ISender mediator,
            CancellationToken cancellationToken) =>
        {
            var query = new DeleteIngredientCommand(ingredientId,cancellationToken);
            var result = await mediator.Send(query);

            if (result.IsFailure)
            {
                return Results.BadRequest(result.Error);
            }
            return Results.Ok(result);
        }).WithTags(Tags.Ingredients);
    }
}