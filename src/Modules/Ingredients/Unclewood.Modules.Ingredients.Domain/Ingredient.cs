using System.Text.Json.Serialization;

namespace Unclewood.Modules.Ingredients.Domain;

public sealed class Ingredient : Entity
{
    [JsonConstructor]
    public Ingredient(
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
   
   // Method to update the name
   public void UpdateName(string newName)
   {
       // Optionally, add validation for newName here
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
   
   private Ingredient() : base(id:Guid.NewGuid())
   {}
}