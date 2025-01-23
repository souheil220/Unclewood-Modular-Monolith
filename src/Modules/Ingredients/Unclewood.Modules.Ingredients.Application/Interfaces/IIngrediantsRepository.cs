using Unclewood.Modules.Ingredients.Domain;

namespace Unclewood.Modules.Ingredients.Application.Interfaces;

public interface IIngrediantsRepository
{
    Task UpdateIngredientAsync(Ingredient ingrediant);
    Task<Ingredient?> GetIngrediantByNameAsync(string ingrediantName);
    Task<Ingredient?> GetIngrediantByIdAsync(Guid id);
    Task<IEnumerable<Ingredient>> GetIngrediantsAsync();
    Task<bool> IngrediantExists(string ingrediantName);
    Task AddIngrediantAsync(Ingredient ingrediant);
    Task DeleteIngrediantAsync(Guid ingrediantId);
}