using Microsoft.Extensions.DependencyInjection;
using PawsPlus.Domain.Common;

namespace PawsPlus.Domain;

public static class DomainConfiguration
{
    public static IServiceCollection AddDomain(this IServiceCollection services)
        => services
            .AddFactories();
    
    public static IServiceCollection AddFactories(this IServiceCollection services)
        => services
            .Scan(scan => scan
                .FromCallingAssembly()
                .AddClasses(classes => classes
                    .AssignableTo(typeof(IFactory<>)))
                .AsImplementedInterfaces()
                .WithTransientLifetime());
}