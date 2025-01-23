using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Unclewood.Modules.Ingredients.Application;
using Unclewood.Modules.Ingredients.Application.Queries.ListIngredient;

namespace Unclewood.Modules.Ingredients.Presentation.Ingredients;

internal class GetIngredients
{
    public static void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("ingredients", async (ISender mediator) =>
        {
            var query = new ListIngredientQuery();
            List<IngredientResponse> ingredientResponses = new();
            var getIngredientsResult = await mediator.Send(query);

            foreach (var ingredient in getIngredientsResult.Value)
            {
                ingredientResponses.Add(new IngredientResponse(
                    ingredient.Id,
                    ingredient.Name,
                    // ToDto(ingredient.DisponibleIn),
                    ingredient.Price.Value
                ));
            }

            return Results.Ok(ingredientResponses);
        }).WithTags(Tags.Ingredients);
    }
}