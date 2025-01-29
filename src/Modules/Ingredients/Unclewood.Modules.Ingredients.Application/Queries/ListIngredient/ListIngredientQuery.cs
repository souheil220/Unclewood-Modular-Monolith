using Unclewood.Common.Application.Messaging;
using Unclewood.Modules.Ingredients.Domain;

namespace Unclewood.Modules.Ingredients.Application.Queries.ListIngredient;

public record ListIngredientQuery : IQuery<List<Ingredient>>;