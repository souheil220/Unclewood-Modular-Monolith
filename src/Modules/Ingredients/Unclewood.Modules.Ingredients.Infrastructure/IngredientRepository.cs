using Microsoft.EntityFrameworkCore;
using Unclewood.Modules.Ingredients.Application.Interfaces;
using Unclewood.Modules.Ingredients.Domain;
using Unclewood.Modules.Ingredients.Infrastructure.Database;

namespace Unclewood.Modules.Ingredients.Infrastructure;

public class IngredientRepository : IIngredientsRepository
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

    public async Task<Ingredient?> GetIngredientByNameAsync(string ingrediantName)
    {
        return await _dbContext.Ingredients.
            Where(i => i.Name == ingrediantName)
            .SingleOrDefaultAsync();
    }

    public async Task<Ingredient?> GetIngredientByIdAsync(Guid id)
    {
        return await _dbContext.Ingredients.FindAsync(id);
    }

    public async Task<List<Ingredient>> GetIngredientsAsync()
    {
        return (await _dbContext.Ingredients.ToListAsync())!;
    }

    public async Task<bool> IngredientExists(string ingredientName)
    {
        return await _dbContext.Ingredients.AnyAsync(x => x.Name == ingredientName.ToLower());

    }

    public async Task AddIngredientAsync(Ingredient ingrediant)
    {
        await _dbContext.Ingredients.AddAsync(ingrediant);
    }

    public void DeleteIngredientAsync(Ingredient ingredient)
    {
        throw new NotImplementedException();
    }

    public void DeleteIngredient(Ingredient ingredient)
    {
        _dbContext.Ingredients.Remove(ingredient);
    }
}
  