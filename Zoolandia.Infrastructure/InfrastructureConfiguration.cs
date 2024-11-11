using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Zoolandia.Application.Common;
using Zoolandia.Application.Identity;
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
            .AddIdentity(configuration)
            .AddSwagger();

    public static IServiceCollection AddDatabase(
        this IServiceCollection services,
        IConfiguration configuration)
        => services
            .AddDbContext<ZoolandiaDbContext>(opt => opt
                .UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection"),
                    sqlServer => sqlServer
                        .MigrationsAssembly(typeof(ZoolandiaDbContext).Assembly.FullName)));
    public static IServiceCollection AddIdentity(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddIdentity<User, IdentityRole>(opt =>
            {
                opt.Password.RequireDigit = false;
                opt.Password.RequireLowercase = false;
                opt.Password.RequireNonAlphanumeric = false;
                opt.Password.RequireUppercase = false;
            })
            .AddEntityFrameworkStores<ZoolandiaDbContext>()
            .AddRoles<IdentityRole>();

        var secret = configuration
            .GetSection(nameof(ApplicationSettings))
            .GetValue<string>(nameof(Secret));
        
        var key = Encoding.ASCII.GetBytes(secret);
        
        services
            .AddAuthentication(authentication =>
            {
                authentication.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                authentication.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(bearer =>
            {
                bearer.RequireHttpsMetadata = false;
                bearer.SaveToken = true;
                bearer.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
        
        services.AddTransient<IIdentity, IdentityService>();
        services.AddTransient<IJwtTokenGenerator, JwtTokenGeneratorService>();
        services.AddScoped<IRoleService, RoleService>();
        
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