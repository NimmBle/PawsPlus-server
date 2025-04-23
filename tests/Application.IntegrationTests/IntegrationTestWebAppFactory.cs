using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PawsPlus.Infrastructure.Common.Persistence;

namespace Application.IntegrationTests;

public class IntegrationTestWebAppFactory : WebApplicationFactory<Program>
{
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

            services.AddDbContext<PawsPlusDbContext>(options =>
            {
                options
                    .UseSqlServer(
                        "Server=.;Database=PawsPlus_Tests;Trusted_Connection=True;MultipleActiveResultSets=true;Trust Server Certificate=true",
                        sqlServer => sqlServer
                            .UseNetTopologySuite()
                            .MigrationsAssembly(typeof(PawsPlusDbContext).Assembly.FullName));
            });
            
            services.AddAuthentication("TestScheme")
                .AddScheme<AuthenticationSchemeOptions, TestAuthHandler>("Test", options => { });
            
            services.AddAuthorization();
        });
        
        builder.Configure(app =>
        {
            app.UseAuthentication();  // Ensure this is added
            app.UseAuthorization();   // Ensure this is added if you use authorization
            app.UseRouting();
        });
        
        base.ConfigureWebHost(builder);
    }
}