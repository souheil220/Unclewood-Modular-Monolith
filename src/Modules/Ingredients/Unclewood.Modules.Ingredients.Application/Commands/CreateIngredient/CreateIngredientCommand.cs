using Unclewood.Common.Application.Messaging;

namespace Unclewood.Modules.Ingredients.Application.Commands.CreateIngredient;

public record CreateIngredientCommand(string Name,
   // List<string> DisponibleIn,
    decimal PriceValue,
    string PriceCurrency
     ): ICommand<IngredientResponse>;