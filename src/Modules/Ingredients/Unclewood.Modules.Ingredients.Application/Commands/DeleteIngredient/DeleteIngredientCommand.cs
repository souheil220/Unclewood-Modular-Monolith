using Unclewood.Common.Application.Messaging;

namespace Unclewood.Modules.Ingredients.Application.Commands.DeleteIngredient;

public record DeleteIngredientCommand(Guid IngredientId, CancellationToken CancellationToken ) : ICommand;