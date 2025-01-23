using System.Data;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Unclewood.Modules.Ingredients.Application.Interfaces;
using Unclewood.Modules.Ingredients.Domain;

namespace Unclewood.Modules.Ingredients.Infrastructure.Database;

public class UnclewoodDbContext(DbContextOptions options
    //, IDateTimeProvider dateTimeProvider
    ) : DbContext(options), IUnitOfWork
{
    
    internal DbSet<Ingredient> Ingredients { get; set; } = null!;
    
   // public DbSet<MealIngredient> MealIngrediants { get; set; }
   
    

    public async Task CommitChangesAsync()
    {
        try
        {
            //PublishDomainEventsAsync();
            await SaveChangesAsync();

        }
        catch (DbUpdateConcurrencyException ex)
        {
           
            throw new DBConcurrencyException(ex.Message);
        }   
       
    }

  /*  private void PublishDomainEventsAsync()
    {
        var outboxMessages = ChangeTracker
            .Entries<Entity>()
            .Select(entry => entry.Entity)
            .SelectMany(entity =>
            {
                var domainEvents = entity.GetDomainEvents();

                entity.ClearDomainEvents();

                return domainEvents;
            })
            .Select(domainEvent => new OutboxMessage(
                Guid.NewGuid(),
                dateTimeProvider.UtcNow,
                domainEvent.GetType().Name,
                JsonConvert.SerializeObject(domainEvent, JsonSerializerSettings)))
            .ToList();

        AddRange(outboxMessages);
    }*/

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(Schemas.Ingredients);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(modelBuilder);
  
       /* modelBuilder.Entity<MealIngredient>()
            .HasKey(mi => new { mi.MealId, mi.IngredientId });
        
        modelBuilder.Entity<MealIngredient>()
            .HasOne(mi => mi.Meal)
            .WithMany(m => m.MealIngredients)
            .HasForeignKey(mi => mi.MealId);

        modelBuilder.Entity<MealIngredient>()
            .HasOne(mi => mi.Ingredient)
            .WithMany(i => i.MealIngrediants)
            .HasForeignKey(mi => mi.IngredientId);*/
        
        
    }
}