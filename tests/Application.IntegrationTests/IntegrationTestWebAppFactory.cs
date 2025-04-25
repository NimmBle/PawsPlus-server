using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NSubstitute;
using PawsPlus.Application.Common.Contracts;
using PawsPlus.Infrastructure.Common.Persistence;

namespace Application.IntegrationTests;

public class IntegrationTestWebAppFactory() : WebApplicationFactory<Program>
{
    public ICurrentUser CurrentUserMock { get; set; }
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureServices(services =>
        {
            var descriptor = services
                .SingleOrDefault(s => s.ServiceType == typeof(DbContextOptions<PawsPlusDbContext>));
            if (descriptor is not null)
            {
                services.Remove(descriptor);
            }
            
            descriptor = services
                .SingleOrDefault(s => s.ServiceType == typeof(ICurrentUser));
            if (descriptor is not null)
            {
                services.Remove(descriptor);
            }

            services.AddDbContext<PawsPlusDbContext>(options =>
            {
                options
                    .UseSqlServer("Server=.;Database=PawsPlus_Tests;Trusted_Connection=True;MultipleActiveResultSets=true;Trust Server Certificate=true",
                        sqlServer => sqlServer
                            .UseNetTopologySuite()
                            .MigrationsAssembly(typeof(PawsPlusDbContext).Assembly.FullName));
            });
            
            services.AddTransient<ICurrentUser>(_ => CurrentUserMock);
            
            services.AddAuthentication("TestScheme")
                .AddScheme<AuthenticationSchemeOptions, TestAuthHandler>("TestScheme", options => { });
            
            services.AddAuthorization();
        });
        
        builder.Configure(app =>
        {
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseRouting();
        });
        
        base.ConfigureWebHost(builder);
    }
}