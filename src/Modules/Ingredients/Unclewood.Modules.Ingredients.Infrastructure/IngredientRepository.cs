using Microsoft.EntityFrameworkCore;
using Unclewood.Modules.Ingredients.Application.Interfaces;
using Unclewood.Modules.Ingredients.Domain;
using Unclewood.Modules.Ingredients.Infrastructure.Database;

namespace Unclewood.Modules.Ingredients.Infrastructure;

public class IngredientRepository : IIngrediantsRepository
{
    private readonly UnclewoodDbContext _dbContext;

    public IngredientRepository(UnclewoodDbContext dbContext)
    {
        _dbContext = dbContext;
    }


    public Task UpdateIngredientAsync(Ingredient ingredient)
    {
        _dbContext.Entry(ingredient).State = EntityState.Modified;
        return Task.CompletedTask;
    }

    public async Task<Ingredient?> GetIngrediantByNameAsync(string ingrediantName)
    {
        return await _dbContext.Ingredients.
            Where(i => i.Name == ingrediantName)
            .SingleOrDefaultAsync();
    }

    public async Task<Ingredient?> GetIngrediantByIdAsync(Guid id)
    {
        return await _dbContext.Ingredients.FindAsync(id);
    }

    public async Task<IEnumerable<Ingredient>> GetIngrediantsAsync()
    {
        return (await _dbContext.Ingredients.ToListAsync())!;
    }

    public async Task<bool> IngrediantExists(string ingrediantName)
    {
        return await _dbContext.Ingredients.AnyAsync(x => x.Name == ingrediantName.ToLower());

    }

    public async Task AddIngrediantAsync(Ingredient ingrediant)
    {
        await _dbContext.Ingredients.AddAsync(ingrediant);
    }

    public async Task DeleteIngrediantAsync(Guid ingrediantId)
    {
        var ingredient = await _dbContext.Ingredients.FindAsync(ingrediantId);
        if (ingredient == null)
        {
            throw new KeyNotFoundException($"Ingredient with ID {ingrediantId} not found.");
        }
        _dbContext.Ingredients.Remove(ingredient);
    }
}
  