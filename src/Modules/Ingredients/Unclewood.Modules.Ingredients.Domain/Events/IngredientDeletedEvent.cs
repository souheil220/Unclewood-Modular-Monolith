namespace Unclewood.Modules.Ingredients.Domain.Events;

public record IngredientDeletedEvent(Guid Id):IDomainEvent;