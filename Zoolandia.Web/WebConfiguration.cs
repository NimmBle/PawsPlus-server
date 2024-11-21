using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using Zoolandia.Application.Common;
using Zoolandia.Application.Common.Contracts;
using Zoolandia.Web.Services;

namespace Zoolandia.Web;

public static class WebConfiguration
{
    public static IServiceCollection AddWebComponents(this IServiceCollection services)
    {
        services
            .AddScoped<ICurrentUser, CurrentUserService>()
            .AddValidatorsFromAssemblyContaining<Result>()
            .AddFluentValidationAutoValidation()
            .AddControllers();

        return services;
    }
}