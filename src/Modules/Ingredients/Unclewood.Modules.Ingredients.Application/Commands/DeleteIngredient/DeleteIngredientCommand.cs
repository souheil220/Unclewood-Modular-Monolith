using Unclewood.Modules.Ingredients.Application.Interfaces.Command;

namespace Unclewood.Modules.Ingredients.Application.Commands.DeleteIngredient;

public record DeleteIngredientCommand(Guid IngredientId ) : ICommand;