using Unclewood.Modules.Ingredients.Application.Interfaces;
using Unclewood.Modules.Ingredients.Application.Interfaces.Command;
using Unclewood.Modules.Ingredients.Domain;

namespace Unclewood.Modules.Ingredients.Application.Commands.UpdateIngredient;

public class UpdateIngredientCommandHandler(IIngredientsRepository ingredientsRepository, IUnitOfWork unitOfWork) : ICommandHandler<UpdateIngredientCommand, IngredientResponse>
{
    public async Task<Result<IngredientResponse>> Handle(UpdateIngredientCommand request, CancellationToken cancellationToken)
    {
        var ingredientExist = await ingredientsRepository.GetIngredientByIdAsync(request.Id);
        if (ingredientExist is null)
        {
            return Result.Failure<IngredientResponse>(IngredientErrors.IngredientNotFound);
        }

        try
        {

            var updatedIngredient = Ingredient.Update(ingredientExist,request.Name,request.PriceValue,request.PriceCurrency);
            await ingredientsRepository.UpdateIngredientAsync(updatedIngredient);
            await unitOfWork.CommitChangesAsync();
       
            return Result.Success(new IngredientResponse(updatedIngredient.Id,
                updatedIngredient.Name,
                //ToDto(ingredientExist.DisponibleIn),
                updatedIngredient.Price.Value));
        }
        catch (Exception e)
        {
            //TODO Write a proper Exception
            Console.WriteLine(e);
            throw;
        }

       
    }
    private static List<string> ToDto(List<Location> locations)
    {
        List<string> result = new();
        foreach (var location in locations)
        {
            result.Add(location.ToString());
        }

        return result;

    }
}