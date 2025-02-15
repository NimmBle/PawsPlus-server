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
using PawsPlus.Application.Common;
using PawsPlus.Application.Files;
using PawsPlus.Application.Identity;
using PawsPlus.Infrastructure.Common.Persistence;
using PawsPlus.Infrastructure.Files;
using PawsPlus.Infrastructure.Identity;
using PawsPlus.Domain.Common;
using PawsPlus.Domain.Services;
using PawsPlus.Infrastructure.Serialization;
using PawsPlus.Infrastructure.Services;

namespace PawsPlus.Infrastructure;

public static class InfrastructureConfiguration
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
        => services
            .AddDatabase(configuration)
            .AddIdentity(configuration)
            .AddSwagger()
            .AddRepositories()
            .AddFiles()
            .AddConverters()
            .AddEmailSender();

    public static IServiceCollection AddDatabase(
        this IServiceCollection services,
        IConfiguration configuration)
        => services
            .AddDbContext<ZoolandiaDbContext>(opt => opt
                .UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection"),
                    sqlServer => sqlServer
                        .UseNetTopologySuite()
                        .MigrationsAssembly(typeof(ZoolandiaDbContext).Assembly.FullName)));
    public static IServiceCollection AddIdentity(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddIdentity<User, IdentityRole>(opt =>
            {
                opt.User.AllowedUserNameCharacters += " ";
                
                opt.Password.RequireDigit = false;
                opt.Password.RequireLowercase = false;
                opt.Password.RequireNonAlphanumeric = false;
                opt.Password.RequireUppercase = false;
            })
            .AddEntityFrameworkStores<ZoolandiaDbContext>()
            .AddDefaultTokenProviders()
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
                .SwaggerDoc("v1", new OpenApiInfo { Title = "PawsPlus API", Version = "v1" }));

    public static IServiceCollection AddRepositories(this IServiceCollection services) 
        => services
            .Scan(scan => scan
                .FromCallingAssembly()
                .AddClasses(classes => classes
                    .AssignableTo(typeof(IDomainRepository<>)))
                .AsImplementedInterfaces()
                .WithTransientLifetime());
    
    public static IServiceCollection AddFiles(this IServiceCollection services)
        => services.AddTransient<IFile, FileService>();

    public static IServiceCollection AddConverters(this IServiceCollection services)
        => services
            .Configure<JsonOptions>(options =>
            {
                options.JsonSerializerOptions.Converters.Add(new TimeOnlyJsonConverter());
            });

    public static IServiceCollection AddEmailSender(this IServiceCollection services)
        => services.AddTransient<IEmailSender, EmailSender>();
}