using Unclewood.Common.Application.Clock;

namespace Unclewood.Commen.Infrastructure.Clock;

public sealed class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}