using Unclewood.Common.Application.Messaging;
using Unclewood.Modules.Ingredients.Application.Interfaces;
using Unclewood.Modules.Ingredients.Domain;

namespace Unclewood.Modules.Ingredients.Application.Queries.ListIngredient;

public class ListIngredientQueryHandler(IIngredientsRepository ingredientsRepository)
    : IQueryHandler<ListIngredientQuery, List<Ingredient>>
{
    public async Task<Result<List<Ingredient>>> Handle(ListIngredientQuery request, CancellationToken cancellationToken)
    {
        var ingredients = await ingredientsRepository.GetIngredientsAsync();
        if (ingredients.Any())  ingredients.First().RaiseIngredientsListedEvent() ; 
        return Result.Success(ingredients);
    }
}