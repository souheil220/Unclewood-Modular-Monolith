using Unclewood.Modules.Ingredients.Domain;

namespace Unclewood.Modules.Ingredients.Application.Interfaces;

public interface IIngredientsRepository
{
    Task UpdateIngredientAsync(Ingredient ingredient);
    Task<Ingredient?> GetIngredientByNameAsync(string ingredientName);
    Task<Ingredient?> GetIngredientByIdAsync(Guid id);
    Task<List<Ingredient>> GetIngredientsAsync();
    Task<bool> IngredientExists(string ingredientName);
    Task AddIngredientAsync(Ingredient ingredient);
    void DeleteIngredient(Ingredient ingredient);
}