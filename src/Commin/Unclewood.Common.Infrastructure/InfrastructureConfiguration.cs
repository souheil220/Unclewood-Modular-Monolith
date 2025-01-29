using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Npgsql;
using Unclewood.Commen.Infrastructure.Clock;
using Unclewood.Commen.Infrastructure.Data;
using Unclewood.Common.Application.Clock;
using Unclewood.Common.Application.Data;

namespace Unclewood.Commen.Infrastructure;

public static class InfrastructureConfiguration
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services,string connectionString)
    {
        var npgSqlDataSource = new NpgsqlDataSourceBuilder().Build();
        services.TryAddSingleton(npgSqlDataSource);
        services.AddSingleton<ISqlConnectionFactory>(_ => new SqlConnectionFactory(connectionString));
        services.AddTransient<IDateTimeProvider, DateTimeProvider>();
        return services;
    }
}