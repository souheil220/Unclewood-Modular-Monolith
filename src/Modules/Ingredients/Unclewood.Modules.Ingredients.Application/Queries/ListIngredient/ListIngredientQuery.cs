using Unclewood.Modules.Ingredients.Application.Interfaces.Query;
using Unclewood.Modules.Ingredients.Domain;

namespace Unclewood.Modules.Ingredients.Application.Queries.ListIngredient;

public record ListIngredientQuery : IQuery<IEnumerable<Ingredient>>;