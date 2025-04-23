using MediatR;
using Microsoft.Extensions.DependencyInjection;
using PawsPlus.Infrastructure.Common.Persistence;

namespace Application.IntegrationTests;

public class BaseIntegrationTest : IClassFixture<IntegrationTestWebAppFactory>
{
    protected readonly IServiceScope _scope;
    protected readonly ISender Sender;
    protected readonly PawsPlusDbContext DbContext;
    
    protected BaseIntegrationTest(IntegrationTestWebAppFactory factory)
    {
        _scope = factory.Services.CreateScope();
        
        Sender = _scope.ServiceProvider.GetRequiredService<ISender>();
        DbContext = _scope.ServiceProvider.GetRequiredService<PawsPlusDbContext>();
    }
}