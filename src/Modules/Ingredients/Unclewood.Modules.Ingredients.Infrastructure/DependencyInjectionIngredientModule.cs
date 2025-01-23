using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Unclewood.Modules.Ingredients.Application;
using Unclewood.Modules.Ingredients.Application.Data;
using Unclewood.Modules.Ingredients.Application.Interfaces;
using Unclewood.Modules.Ingredients.Infrastructure.Clock;
using Unclewood.Modules.Ingredients.Infrastructure.Data;
using Unclewood.Modules.Ingredients.Infrastructure.Database;
using Unclewood.Modules.Ingredients.Presentation;

namespace Unclewood.Modules.Ingredients.Infrastructure;

public static class DependencyInjectionIngredientModule
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, 
        IConfiguration configuration)
    {

            services.AddTransient<IDateTimeProvider, DateTimeProvider>();

            services.AddMediatR(options =>
            {
                options.RegisterServicesFromAssembly
                    (AssemblyReference.Assembly);
            });

            AddIngredientsModule(services, configuration);
          
          //  AddAuthentication(services, configuration);
            //AddAuthorization(services);
            //AddCaching(services, configuration);
            //AddHealthChecks(services, configuration);
            //AddApiVersioning(services);
            //AddBackgroundJobs(services, configuration);
            
            return services;
    }

    /*private static void AddAuthentication(IServiceCollection services, IConfiguration configuration)
    {
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                // Add these events for debugging
                options.Events = new JwtBearerEvents
                {
                    OnAuthenticationFailed = context =>
                    {
                        Console.WriteLine($"Authentication failed: {context.Exception}");
                        return Task.CompletedTask;
                    },
                    OnTokenValidated = context =>
                    {
                        Console.WriteLine("Token validated successfully");
                        return Task.CompletedTask;
                    },
                    OnMessageReceived = context =>
                    {
                        Console.WriteLine($"Token received: {context.Token}");
                        return Task.CompletedTask;
                    }
                };
            });
        services.Configure<AuthenticationOptions>(configuration.GetSection("Authentication"));
        services.ConfigureOptions<JwtBearerOptionsSetup>();
        services.Configure<KeycloakOptions>(configuration.GetSection("Keycloak"));
        services.AddTransient<AdminAuthorizationDelegatingHandler>();

        services.AddHttpClient<IAuthenticationService, AuthenticationService>((serviceProvider, httpClient) =>
            {
                var keycloakOptions = serviceProvider.GetRequiredService<IOptions<KeycloakOptions>>().Value;

                httpClient.BaseAddress = new Uri(keycloakOptions.AdminUrl);
            })
            .AddHttpMessageHandler<AdminAuthorizationDelegatingHandler>();
       
        services.AddHttpClient<IJwtService, JwtService>((serviceProvider, httpClient) =>
        {
            var keycloakOptions = serviceProvider.GetRequiredService<IOptions<KeycloakOptions>>().Value;

            httpClient.BaseAddress = new Uri(keycloakOptions.TokenUrl);
        });
        services.AddScoped<IUserContext, UserContext>();
    }*/
    public static void MapEndPoints(IEndpointRouteBuilder app)
    {
        IngredientsEndPoints.MapEndPoints(app);
    }
    public static void AddIngredientsModule(IServiceCollection services,IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection") ?? 
                               throw new ArgumentNullException(nameof(configuration));
        
        services.AddDbContext<UnclewoodDbContext>(options =>
            options.UseNpgsql(connectionString,
                npgsqlOptions
                    => npgsqlOptions.MigrationsHistoryTable(HistoryRepository.DefaultTableName,
                                                                    Schemas.Ingredients))
                .UseSnakeCaseNamingConvention());

        services.AddSingleton<ISqlConnectionFactory>(_ => new SqlConnectionFactory(connectionString));
        
        services.AddScoped<IIngrediantsRepository, IngredientRepository>();
        services.AddScoped<IUnitOfWork>(serviceProvider => serviceProvider.GetRequiredService<UnclewoodDbContext>());

    }
    
   /* private static void AddAuthorization(IServiceCollection services)
    {
        services.AddScoped<AuthorizationService>();

        services.AddTransient<IClaimsTransformation, CustomClaimsTransformation>();

        services.AddTransient<IAuthorizationHandler, PermissionAuthorizationHandler>();

        services.AddTransient<IAuthorizationPolicyProvider, PermissionAuthorizationPolicyProvider>();
    }*/
    
   /* private static void AddCaching(IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("Cache") ??
                               throw new ArgumentNullException(nameof(configuration));

        services.AddStackExchangeRedisCache(options => options.Configuration = connectionString);

        services.AddSingleton<ICacheService, CacheService>();
    }*/
    
    /*private static void AddHealthChecks(IServiceCollection services, IConfiguration configuration)
    {
        services.AddHealthChecks()
            .AddNpgSql(configuration.GetConnectionString("DefaultConnection")!)
            .AddRedis(configuration.GetConnectionString("Cache")!)
            .AddUrlGroup(new Uri(configuration["KeyCloak:BaseUrl"]!), HttpMethod.Get, "keycloak");
    }*/
    
    /*private static void AddApiVersioning(IServiceCollection services)
    {
        services
            .AddApiVersioning(options =>
            {
                options.DefaultApiVersion = new ApiVersion(1);
                options.ReportApiVersions = true;
                options.ApiVersionReader = new UrlSegmentApiVersionReader();
            })
            .AddMvc()
            .AddApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'V";
                options.SubstituteApiVersionInUrl = true;
            });
    }*/
    
   /*private static void AddBackgroundJobs(IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<OutboxOptions>(configuration.GetSection("Outbox"));

        services.AddQuartz();

        services.AddQuartzHostedService(options => options.WaitForJobsToComplete = true);

        services.ConfigureOptions<ProcessOutboxMessagesJobSetup>();
    }*/
}