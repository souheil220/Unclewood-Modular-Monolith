using System.Text.Json.Serialization;
using Unclewood.Modules.Ingredients.Domain.Events;

namespace Unclewood.Modules.Ingredients.Domain;

public sealed class Ingredient : Entity
{
    [JsonConstructor]
    private Ingredient(
        Name name, 
        //List<Location> disponibleIn,
        Price price,
        Guid? id=null) : base(id??Guid.NewGuid())
    {
        Name = name;
       // DisponibleIn = disponibleIn;
        Price = price;
    }
    public Name Name { get; private set; }
    
   // public List<Location> DisponibleIn { get; private set; } = new();
    
    public Price Price { get; private set; }
   
   //public List<MealIngredient> MealIngrediants { get; set; } = new();

   public static Ingredient Create(Name name, Price price)
   {
       var ingredient = new Ingredient(
           name,
           price
           );
       ingredient.RaiseDomainEvent(new IngredientCreatedEvent(ingredient.Id));
       return ingredient;
   }
   
   public static Ingredient Update(Ingredient currentIngredient,string? name,  decimal priceValue,string priceCurrency)
   {
       if (name is not null)
       {
           currentIngredient.UpdateName(name);
       }

       /*if (request.DisponibleIn is not null)
       {
         //  ingredientExist.UpdateLocation(request.DisponibleIn) ;
       }*/

       if (priceValue > 0 )
       {
           currentIngredient.UpdatePrice(priceValue, priceCurrency);
       }
       currentIngredient.RaiseDomainEvent(new IngredientUpdatedEvent(currentIngredient.Id));
       return currentIngredient;
   }
   public void UpdateName(string newName)
   {
       Name = Name.Create(newName);
   }

   public void UpdatePrice(decimal newPrice , string priceCurrency)
   {
       Price =  Price.Create(newPrice, priceCurrency);
   }
   
 /*  public void UpdateLocation(List<string> locations)
   {
       DisponibleIn.Clear();
       foreach (var finalLocation in locations)
       {
         //  DisponibleIn.Add(Location.);
       }
   }*/
 
 
 
 public void RaiseIngredientDeletedEvent()
 {
    RaiseDomainEvent(new IngredientDeletedEvent(Id));
 }
 
 public void RaiseIngredientListedEvent()
 {
   RaiseDomainEvent(new IngredientListedEvent(Id));
 }
 
 public void RaiseIngredientsListedEvent()
 {
     RaiseDomainEvent(new IngredientsListedEvent(Id));
 }
 
   
   private Ingredient() : base(id:Guid.NewGuid())
   {}
}