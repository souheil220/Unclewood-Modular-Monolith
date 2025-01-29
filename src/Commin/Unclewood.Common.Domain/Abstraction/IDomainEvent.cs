namespace Unclewood.Common.Domain.Abstraction;

public interface IDomainEvent
{
    Guid Id { get; }
    DateTime OccurredOnUtc { get; }
};