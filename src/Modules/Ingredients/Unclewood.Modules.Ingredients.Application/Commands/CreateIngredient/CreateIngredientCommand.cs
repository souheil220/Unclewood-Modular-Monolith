using Unclewood.Modules.Ingredients.Application.Interfaces.Command;
using Unclewood.Modules.Ingredients.Domain;

namespace Unclewood.Modules.Ingredients.Application.Commands.CreateIngredient;

public record CreateIngredientCommand(string Name,
   // List<string> DisponibleIn,
    decimal PriceValue,
    string PriceCurrency
     ): ICommand<IngredientResponse>;