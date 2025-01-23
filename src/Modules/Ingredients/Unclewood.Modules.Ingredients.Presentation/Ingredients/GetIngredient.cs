using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Unclewood.Modules.Ingredients.Application.Queries.GetIngredient;

namespace Unclewood.Modules.Ingredients.Presentation.Ingredients;

internal static class GetIngredient
{
    public static void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("ingredients/{id:guid}", async (Guid id, ISender mediator)=>
        {
            var query = new GetIngredientQuery(id);
            var getIngredientsResult = await mediator.Send(query);
            if (getIngredientsResult.IsFailure)
            {
                return Results.BadRequest(getIngredientsResult.Error);
            }
            return Results.Ok(getIngredientsResult.Value);
        }).WithTags(Tags.Ingredients);
    }
}