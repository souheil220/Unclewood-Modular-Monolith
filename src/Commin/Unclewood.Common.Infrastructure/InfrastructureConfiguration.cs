using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Npgsql;
using StackExchange.Redis;
using Unclewood.Commen.Infrastructure.Caching;
using Unclewood.Commen.Infrastructure.Clock;
using Unclewood.Commen.Infrastructure.Data;
using Unclewood.Common.Application.Caching;
using Unclewood.Common.Application.Clock;
using Unclewood.Common.Application.Data;

namespace Unclewood.Commen.Infrastructure;

public static class InfrastructureConfiguration
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services,
        string connectionString,
        string redisConnectionString)
    {
        var npgSqlDataSource = new NpgsqlDataSourceBuilder(connectionString).Build();
        services.TryAddSingleton(npgSqlDataSource);
        services.AddSingleton<ISqlConnectionFactory>(_ => new SqlConnectionFactory(connectionString));
        services.AddTransient<IDateTimeProvider, DateTimeProvider>();
        
        IConnectionMultiplexer connectionMultiplexer = ConnectionMultiplexer.Connect(redisConnectionString);
        services.TryAddSingleton(connectionMultiplexer);
        
        services.AddStackExchangeRedisCache(options => 
            options.ConnectionMultiplexerFactory = () => Task.FromResult(connectionMultiplexer));

        
        services.TryAddSingleton<ICacheService, CacheService>();
        return services;
    }
}