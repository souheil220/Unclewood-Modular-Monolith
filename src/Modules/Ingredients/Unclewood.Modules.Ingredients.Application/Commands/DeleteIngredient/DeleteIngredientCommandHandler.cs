using Unclewood.Modules.Ingredients.Application.Interfaces;
using Unclewood.Modules.Ingredients.Application.Interfaces.Command;
using Unclewood.Modules.Ingredients.Domain;

namespace Unclewood.Modules.Ingredients.Application.Commands.DeleteIngredient;

public class DeleteIngredientCommandHandler:ICommandHandler<DeleteIngredientCommand>
{
    private readonly IIngrediantsRepository _ingrediantsRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteIngredientCommandHandler(IIngrediantsRepository ingrediants, IUnitOfWork unitOfWork)
    {
        _ingrediantsRepository = ingrediants;
        _unitOfWork = unitOfWork;
    }
    public async Task<Result> Handle(DeleteIngredientCommand request, CancellationToken cancellationToken)
    {
        try
        {
            await _ingrediantsRepository.DeleteIngrediantAsync(request.IngredientId);
            await _unitOfWork.CommitChangesAsync();
            return Result.Success();
        }
        catch (Exception e)
        {
           return Result.Failure<Ingredient>(new Error("Exception",e.Message));
        }
       
    }
}