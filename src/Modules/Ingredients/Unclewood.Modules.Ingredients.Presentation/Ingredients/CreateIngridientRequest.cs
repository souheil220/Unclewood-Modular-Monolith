namespace Unclewood.Modules.Ingredients.Presentation.Ingredients;

internal record CreateIngridientRequest(string Name, 
    //List<string> DisponibleIn,
    decimal PriceValue, 
    string PriceCurrency);