using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Zoolandia.Applicaiton;

public static class ApplicationConfiguration
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
        => services
            .AddMediatR(cfg => cfg 
                .RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
}