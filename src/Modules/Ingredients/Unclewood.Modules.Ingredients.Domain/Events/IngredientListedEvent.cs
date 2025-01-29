using Unclewood.Common.Domain.Abstraction;

namespace Unclewood.Modules.Ingredients.Domain.Events;

public class IngredientListedEvent(Guid eventId):DomainEvent
{
    public Guid EventId { get; init; } = eventId;
}