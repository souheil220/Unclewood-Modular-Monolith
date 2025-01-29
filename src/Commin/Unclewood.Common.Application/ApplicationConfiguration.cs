using System.Reflection;
using System.Reflection.Metadata;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Unclewood.Common.Application;

public static  class ApplicationConfiguration
{
    public static IServiceCollection AddApplication(this IServiceCollection services,
        Assembly[] moduleAssemblies)
    {
        services.AddMediatR(options =>
        {
            options.RegisterServicesFromAssemblies(moduleAssemblies);
        });

        services.AddValidatorsFromAssemblies(moduleAssemblies,includeInternalTypes:true);
        return services;
    }

    
}