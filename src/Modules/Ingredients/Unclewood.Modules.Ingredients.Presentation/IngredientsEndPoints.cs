using Microsoft.AspNetCore.Routing;
using Unclewood.Modules.Ingredients.Presentation.Ingredients;

namespace Unclewood.Modules.Ingredients.Presentation;

public static class IngredientsEndPoints
{
    public static void MapEndPoints(IEndpointRouteBuilder app)
    {
        CreateIngredient.MapEndpoint(app);
        GetIngredient.MapEndpoint(app);
        GetIngredients.MapEndpoint(app);
    }
}