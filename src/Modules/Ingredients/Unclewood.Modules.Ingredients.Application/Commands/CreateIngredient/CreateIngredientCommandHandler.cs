using Unclewood.Modules.Ingredients.Application.Interfaces;
using Unclewood.Modules.Ingredients.Application.Interfaces.Command;
using Unclewood.Modules.Ingredients.Domain;

namespace Unclewood.Modules.Ingredients.Application.Commands.CreateIngredient;

public class CreateIngredientCommandHandler(IIngrediantsRepository ingrediantsRepository, IUnitOfWork unitOfWork)
    : ICommandHandler<CreateIngredientCommand, IngredientResponse>
{
    public async Task<Result<IngredientResponse>> Handle(CreateIngredientCommand request, CancellationToken cancellationToken)
    {
        var ingridientExist = await ingrediantsRepository.IngrediantExists(request.Name);
        if (ingridientExist)
        {
            return Result.Failure<IngredientResponse>(IngredientErrors.IngredientAlreadyExist);
        }
        var ingredient = new Ingredient(
            name:Name.Create(request.Name),
          //  disponibleIn:EnumConverter(request.DisponibleIn),
            price:  Price.Create(request.PriceValue,request.PriceCurrency)
            );
        await ingrediantsRepository.AddIngrediantAsync(ingredient);
        await unitOfWork.CommitChangesAsync();
        
        var ingredientRespponse = new IngredientResponse(
            ingredient.Id,
            ingredient.Name,
            ingredient.Price.Value
        );
        return Result.Success(ingredientRespponse);
    }
    
    private static List<Location> EnumConverter(List<string> locations)
    {
        List<Location> result = new();
        foreach (var location in locations)
        {
           
            result.Add((Location)Enum.Parse(typeof(Location), location));
        }
        return result;
    }
    
  
}