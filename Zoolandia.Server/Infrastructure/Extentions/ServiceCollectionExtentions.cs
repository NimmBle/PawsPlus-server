using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Zoolandia.Server.Data;
using Zoolandia.Server.Data.Models;

namespace Zoolandia.Server.Infrastructure.Extentions;

public static class ServiceCollectionExtentions
{
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
