using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Zoolandia.Infrastructure.Data;
using Zoolandia.Infrastructure.Identity;

namespace Zoolandia.Infrastructure;

public static class InfrastructureConfiguration
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
        => services
            .AddDatabase(configuration)
            .AddIdentity()
            .AddSwagger();
    
    public static IServiceCollection AddDatabase(
        this IServiceCollection services,
        IConfiguration configuration)
        => services
            .AddDbContext<ZoolandiaDbContext>(opt => opt
                .UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

    public static IServiceCollection AddIdentity(this IServiceCollection services)
    {
        services.AddIdentity<User, IdentityRole>(opt =>
            {
                opt.Password.RequireDigit = false;
                opt.Password.RequireLowercase = false;
                opt.Password.RequireNonAlphanumeric = false;
                opt.Password.RequireUppercase = false;
            })
            .AddEntityFrameworkStores<ZoolandiaDbContext>();

        return services;
    }
    
        
    public static IServiceCollection AddSwagger(this IServiceCollection services)
        => services
            .AddApiVersioning(opt =>
            {
                opt.DefaultApiVersion = new ApiVersion(1, 0);
                opt.AssumeDefaultVersionWhenUnspecified = true;
                opt.ReportApiVersions = true;
            })
            .AddSwaggerGen(opt => opt
                .SwaggerDoc("v1", new OpenApiInfo { Title = "Zoolandia API", Version = "v1" }));
}