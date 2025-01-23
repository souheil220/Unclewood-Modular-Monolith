namespace Unclewood.Modules.Ingredients.Infrastructure.Clock;

public interface IDateTimeProvider
{
    DateTime UtcNow { get; }
}