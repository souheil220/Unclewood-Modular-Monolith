using Unclewood.Common.Application.Messaging;

namespace Unclewood.Modules.Ingredients.Application.Commands.UpdateIngredient;

public record UpdateIngredientCommand(
    Guid Id,
    string? Name,
    //List<string>? DisponibleIn,
    string PriceCurrency = "DZD",
    decimal PriceValue = 0): ICommand<IngredientResponse>;