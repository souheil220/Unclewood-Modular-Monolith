using Unclewood.Modules.Ingredients.Application.Interfaces;
using Unclewood.Modules.Ingredients.Application.Interfaces.Command;
using Unclewood.Modules.Ingredients.Domain;

namespace Unclewood.Modules.Ingredients.Application.Commands.DeleteIngredient;

public class DeleteIngredientCommandHandler:ICommandHandler<DeleteIngredientCommand>
{
    private readonly IIngredientsRepository _ingredientsRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteIngredientCommandHandler(IIngredientsRepository ingredients, IUnitOfWork unitOfWork)
    {
        _ingredientsRepository = ingredients;
        _unitOfWork = unitOfWork;
    }
    public async Task<Result> Handle(DeleteIngredientCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var ingredient = await _ingredientsRepository.GetIngredientByIdAsync(request.IngredientId);
            if (ingredient == null)
            {
                return Result.Failure<Ingredient>(IngredientErrors.IngredientNotFound);
            }
            _ingredientsRepository.DeleteIngredient(ingredient);
            await _unitOfWork.CommitChangesAsync();
            ingredient.RaiseIngredientDeletedEvent();
            return Result.Success();
        }
        catch (Exception e)
        {
           return Result.Failure<Ingredient>(new Error("Exception",e.Message));
        }
       
    }
}