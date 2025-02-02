using System.Reflection;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Unclewood.Common.Application.Behavior;

namespace Unclewood.Common.Application;

public static  class ApplicationConfiguration
{
    public static IServiceCollection AddApplication(this IServiceCollection services,
        Assembly[] moduleAssemblies)
    {
        services.AddMediatR(options =>
        {
            options.RegisterServicesFromAssemblies(moduleAssemblies);
            
            options.AddOpenBehavior(typeof(ExceptionHandlingPipelineBehavior<,>));
            options.AddOpenBehavior(typeof(RequestLoggingPipelineBehavior<,>));
            options.AddOpenBehavior(typeof(ValidationPipelineBehavior<,>));
        });

        services.AddValidatorsFromAssemblies(moduleAssemblies,includeInternalTypes:true);
        return services;
    }

    
}