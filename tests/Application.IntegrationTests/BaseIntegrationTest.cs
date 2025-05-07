using Bogus;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NSubstitute;
using PawsPlus.Application.Common.Contracts;
using PawsPlus.Domain.Enums;
using PawsPlus.Domain.Enums.Pet;
using PawsPlus.Domain.Factories.Pet;
using PawsPlus.Domain.Models;
using PawsPlus.Infrastructure.Common.Persistence;
using PawsPlus.Infrastructure.Identity;
using PawsPlus.Server;

namespace Application.IntegrationTests;

public class BaseIntegrationTest : IClassFixture<IntegrationTestWebAppFactory>
{
    protected readonly IServiceScope _scope;
    protected readonly IPetFactory _petFactory;
    protected readonly Faker _faker = new();
    protected readonly ISender Sender;
    protected readonly PawsPlusDbContext DbContext;
    protected readonly IntegrationTestWebAppFactory _factory;
    
    protected BaseIntegrationTest(IntegrationTestWebAppFactory factory)
    {
        FirebaseInitializer.EnsureInitialized();
        
        _factory = factory;
        _scope = factory.Services.CreateScope();
        _petFactory = _scope.ServiceProvider.GetService<IPetFactory>();
        Sender = _scope.ServiceProvider.GetRequiredService<ISender>();
        DbContext = _scope.ServiceProvider.GetRequiredService<PawsPlusDbContext>();
    }
    
    public async Task<IdsOutputModel> CreateTestUser()
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
        
        profile.UpdateLocation(_faker.Lorem.Sentence(5),
            _faker.Random.Double(-90, 90),
            _faker.Random.Double(-180, 180));
        
        await DbContext.Profiles.AddAsync(profile);
        await DbContext.SaveChangesAsync();
        

        return new IdsOutputModel(user.Id, profile.Id);
    }

    public async Task<PawsPlus.Domain.Models.Post> CreateTestPost()
    {
        var ids = await CreateTestUser();
        List<Animal> animalTypes = await DbContext.Animals.ToListAsync();
        List<Weight> weights = await DbContext.Weights.ToListAsync();

        PawsPlus.Domain.Models.Post post = new(animalTypes,
            weights,
            ids.ProfileId);
        
        DbContext.Posts.Add(post);
        await DbContext.SaveChangesAsync();

        return post;
    }

    public async Task<PawsPlus.Domain.Models.Service> CreateTestService()
    {
        var post = await CreateTestPost();
        var allDates = await DbContext.Dates.ToListAsync();
        var meetingPlace = await DbContext.MeetingPlaces.ToListAsync();
        var service = new PawsPlus.Domain.Models.Service(_faker.Random.Enum<ServiceType>(),
            _faker.Random.Int(1, 100),
            new List<DateOnly>
            {
                DateOnly.FromDateTime(DateTime.Today),
                DateOnly.FromDateTime(DateTime.Today.AddDays(1)),
                DateOnly.FromDateTime(DateTime.Today.AddDays(2)),
                DateOnly.FromDateTime(DateTime.Today.AddDays(3))
            },
            meetingPlace,
            post.Id,
            allDates);
        
        DbContext.Services.Add(service);
        await DbContext.SaveChangesAsync();
        return service;
    }
    
    public async Task<PawsPlus.Domain.Models.Service> CreateTestServiceFromPost(string postId)
    {
        var allDates = await DbContext.Dates.ToListAsync();
        var meetingPlace = await DbContext.MeetingPlaces.ToListAsync();
        var service = new PawsPlus.Domain.Models.Service(_faker.Random.Enum<ServiceType>(),
            _faker.Random.Int(1, 100),
            new List<DateOnly>
            {
                DateOnly.FromDateTime(DateTime.Today),
                DateOnly.FromDateTime(DateTime.Today.AddDays(1)),
                DateOnly.FromDateTime(DateTime.Today.AddDays(2)),
                DateOnly.FromDateTime(DateTime.Today.AddDays(3))
            },
            meetingPlace,
            postId,
            allDates);
        
        DbContext.Services.Add(service);
        await DbContext.SaveChangesAsync();
        return service;
    }

    public async Task<PawsPlus.Domain.Models.Pet> CreatePetForUser(string profileId)
    {
        Animal animal = await DbContext.Animals.FirstAsync();
        Weight weight = await DbContext.Weights.FirstAsync();
        List<Breed> breeds = await DbContext.Breeds.Take(2).ToListAsync();
        var pet = _petFactory
            .WithName(_faker.Name.FirstName())
            .WithPhotoUrl(_faker.Internet.Url())
            .WithType(animal)
            .WithAge(_faker.Random.Int(1, 20),
                _faker.Random.Int(1, 12))
            .WithGender(_faker.Random.Enum<Gender>())
            .WithBreed(breeds)
            .WithPersonality(
                _faker.Lorem.Sentence(2),
                _faker.Lorem.Sentence(1),
                _faker.Random.Enum<Training>(),
                _faker.Random.Enum<Fear>(),
                _faker.Lorem.Sentence(10))
            .WithHealthStatus(
                _faker.Random.Bool(),
                _faker.Random.Bool(),
                _faker.Random.Bool(),
                _faker.Lorem.Sentence(20),
                _faker.Lorem.Sentence(25),
                _faker.Lorem.Sentence(25))
            .WithProfileId(profileId)
            .WithWeight(weight)
            .Build();
        
        DbContext.Pets.Add(pet);
        await DbContext.Pets.AddAsync(pet);
        return pet;
    }
    
    
    public async Task<IMediator> ConfigureCurrentUser(string userId, string profileId)
    {
        var currentUserMock = Substitute.For<ICurrentUser>();
        currentUserMock.UserId.Returns(userId);
        _factory.CurrentUserMock = currentUserMock;
        
        var sender = _scope.ServiceProvider.GetRequiredService<IMediator>();
        return sender;
    }
}