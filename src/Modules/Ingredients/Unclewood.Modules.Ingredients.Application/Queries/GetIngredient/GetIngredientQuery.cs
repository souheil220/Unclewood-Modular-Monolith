using Unclewood.Common.Application.Messaging;

namespace Unclewood.Modules.Ingredients.Application.Queries.GetIngredient;

//public record GetIngredientQuery(Guid IngredientId) : ICachedQuery<IngredientResponse>
public record GetIngredientQuery(Guid IngredientId) : IQuery<IngredientResponse>
{
    public string CacheKey => $"Ingredient-{IngredientId}";
    public TimeSpan? Expiration => null;
}