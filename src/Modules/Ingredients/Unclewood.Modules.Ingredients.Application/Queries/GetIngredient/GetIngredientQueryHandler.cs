using Unclewood.Common.Application.Messaging;
using Unclewood.Common.Domain.Abstraction;
using Unclewood.Modules.Ingredients.Application.Interfaces;
using Unclewood.Modules.Ingredients.Domain;

namespace Unclewood.Modules.Ingredients.Application.Queries.GetIngredient;

public class GetIngredientQueryHandler(IIngredientsRepository ingredientsRepository)
    : IQueryHandler<GetIngredientQuery, IngredientResponse>
{
    public async Task<Result<IngredientResponse>> Handle(GetIngredientQuery request, CancellationToken cancellationToken)
    {
        var ingredient = await ingredientsRepository.GetIngredientByIdAsync(request.IngredientId);
        

        if (ingredient is not null)
        {
            var ingredientResponse = new IngredientResponse(
                Id: ingredient.Id,
                Name: ingredient.Name.Value,
             //   DisponibleIn: ingredient.DisponibleIn.Select(l => l.ToString()).ToList(),
                Price: ingredient.Price.Value
            );
            ingredient.RaiseIngredientListedEvent();
            return Result.Success(ingredientResponse!);
        }

        return Result.Failure<IngredientResponse>(IngredientErrors.IngredientNotFound);

    }
}