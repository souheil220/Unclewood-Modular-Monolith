using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unclewood.Modules.Ingredients.Domain;

namespace Unclewood.Modules.Ingredients.Infrastructure;

public class IngredientConfigurations : IEntityTypeConfiguration<Ingredient>
{
    public void Configure(EntityTypeBuilder<Ingredient> builder)
    {
        builder.HasKey(s => s.Id);

        builder.Property(s => s.Id)
            .ValueGeneratedNever();

        builder.Property(m => m.Name)
            .HasConversion(
                name => name.Value, 
                value => Name.Create(value));
        
        builder.OwnsOne(i => i.Price, priceBuilder =>
        {
            priceBuilder.Property(p => p.Value)
                .IsRequired();
            priceBuilder.Property(p => p.Currency)
                .IsRequired();
        });
        
      /*  builder.OwnsMany<Ingredient, Location>(i => i.DisponibleIn, disponibleInBuilder =>
        {
            disponibleInBuilder.WithOwner()
                .HasForeignKey("IngredientId");

            disponibleInBuilder.Property(l => l.Value)
                .HasColumnName("DisponibleInValue")
                .IsRequired();
        });*/
        
    }
}
