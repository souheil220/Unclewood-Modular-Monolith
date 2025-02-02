using Unclewood.Common.Domain.Abstraction;

namespace Unclewood.Modules.Ingredients.Domain;

public class IngredientErrors
{
    public static Error IngredientNotFound => new(
        "Ingredient.Found",
        "The ingredient with the specified id doesn't exist.",
        ErrorType.NotFound
    );
    
    public static Error IngredientAlreadyExist => new(
        "Ingredient.Exist",
        "The ingredient specified already exist.",
        ErrorType.Conflict
    );
}