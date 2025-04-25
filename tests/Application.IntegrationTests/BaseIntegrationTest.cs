using Bogus;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using NSubstitute;
using PawsPlus.Application.Common.Contracts;
using PawsPlus.Infrastructure.Common.Persistence;
using PawsPlus.Infrastructure.Identity;

namespace Application.IntegrationTests;

public class BaseIntegrationTest : IClassFixture<IntegrationTestWebAppFactory>
{
    protected readonly IServiceScope _scope;
    protected readonly Faker _faker = new();
    protected readonly ISender Sender;
    protected readonly PawsPlusDbContext DbContext;
    
    protected BaseIntegrationTest(IntegrationTestWebAppFactory factory)
    {
        _scope = factory.Services.CreateScope();
        
        Sender = _scope.ServiceProvider.GetRequiredService<ISender>();
        DbContext = _scope.ServiceProvider.GetRequiredService<PawsPlusDbContext>();
    }
    
    public async Task<string> CreateTestUserAsync()
    {
        var firstName = _faker.Name.FirstName();
        var lastName = _faker.Name.LastName();
        var user = new User(_faker.Person.Email, firstName + lastName);
        var profile = new PawsPlus.Domain.Models.Profile(firstName,
            lastName,
            _faker.Phone.PhoneNumber("##########")
        );
        await DbContext.Users.AddAsync(user);
        
        user.CreateProfile(profile);
        
        await DbContext.Profiles.AddAsync(profile);
        await DbContext.SaveChangesAsync();

        return profile.Id;
    }
}