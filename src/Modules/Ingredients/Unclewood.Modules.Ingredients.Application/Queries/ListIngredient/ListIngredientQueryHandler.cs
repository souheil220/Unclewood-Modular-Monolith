using Unclewood.Modules.Ingredients.Application.Interfaces;
using Unclewood.Modules.Ingredients.Application.Interfaces.Query;
using Unclewood.Modules.Ingredients.Domain;

namespace Unclewood.Modules.Ingredients.Application.Queries.ListIngredient;

public class ListIngredientQueryHandler(IIngrediantsRepository ingrediantsRepository)
    : IQueryHandler<ListIngredientQuery, IEnumerable<Ingredient>>
{
    public async Task<Result<IEnumerable<Ingredient>>> Handle(ListIngredientQuery request, CancellationToken cancellationToken)
    {
        var ingredients = await ingrediantsRepository.GetIngrediantsAsync();
        
        return Result.Success(ingredients);
    }
}