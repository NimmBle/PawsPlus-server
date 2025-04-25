using Bogus;
using Microsoft.EntityFrameworkCore;
using PawsPlus.Application.Features.Post.Commands.Create;
using PawsPlus.Domain.Enums;
using PawsPlus.Domain.Models;
using PawsPlus.Infrastructure.Identity;
using Shouldly;

namespace Application.IntegrationTests.Post.Commands;

public class CreatePostCommandHandlerTest : BaseIntegrationTest
{

    // private readonly Faker _faker = new Faker();
    public CreatePostCommandHandlerTest(IntegrationTestWebAppFactory factory) 
        : base(factory)
    {
    }

    [Fact]
    public async Task CreatePost_WithValidData_ShouldSucceed()
    {
        // Arrange
        var profileId = await CreateTestUserAsync();
        List<int> pets = new List<int>() { _faker.Random.Int(1, 2) };
        List<int> weight  = new List<int>() { _faker.Random.Int(1, 4) };
        
        var command = new CreatePostCommand
        {
            profileId = profileId,
            Services = new List<ServiceType> { _faker.Random.Enum<ServiceType>() },
            Pets = pets,
            Weights = weight
        };

        // Act
        var result = await Sender.Send(command);

        // Assert
        result.Succeeded.ShouldBeTrue();
        
        var savedPost = await DbContext.Posts
            .Where(p => p.ProfileId == profileId)
            .Include(p => p.Animals)
            .Include(p => p.Weights)
            .FirstOrDefaultAsync();

        savedPost.ShouldNotBeNull();
        savedPost.Animals.ShouldContain(at => at.Id == pets.First());
        savedPost.Weights.ShouldContain(w => w.Id == weight.First());
    }
    
    // [Fact]
    // public async Task CreatePost_WithValidData_ShouldSucceed()
    // {
    //     // Arrange
    //     // Seed test data
    //     var firstName = _faker.Name.FirstName();
    //     var lastName = _faker.Name.LastName();
    //     var user = new User(_faker.Person.Email, firstName + lastName);
    //     var profile = new PawsPlus.Domain.Models.Profile(firstName,
    //         lastName,
    //         _faker.Phone.PhoneNumber("##########")
    //     );
    //     await DbContext.Users.AddAsync(user);
    //     
    //     user.CreateProfile(profile);
    //     
    //     await DbContext.Profiles.AddAsync(profile);
    //     await DbContext.SaveChangesAsync();
    //
    //     var animalType = new Animal(_faker.Random.Int(1, 100000), _faker.Person.FirstName);
    //     var weight = new Weight(_faker.Random.Int(1, 100000), _faker.Person.FirstName);
    //     
    //     await DbContext.Animals.AddAsync(animalType);
    //     await DbContext.Weights.AddAsync(weight);
    //     await DbContext.SaveChangesAsync();
    //     
    //     var animalTypes = new List<int> { _faker.Random.Int(1, 140), _faker.Random.Int(1, 140) };
    //     var weights = new List<int> { _faker.Random.Int(1, 3) };
    //
    //     // Build the command
    //     var command = new CreatePostCommand
    //     {
    //         profileId = user.Id,
    //         Services = new List<ServiceType> { _faker.Random.Enum<ServiceType>() },
    //         Pets = animalTypes,
    //         Weights = weights
    //     };
    //
    //     // Act
    //     var result = await Sender.Send(command);
    //
    //     // Assert
    //     result.Succeeded.ShouldBeTrue();
    //
    //     // Verify the post was saved
    //     var savedPost = await DbContext.Posts
    //         .Where(p => p.ProfileId == user.Id)
    //         .Include(p => p.Animals)
    //         .Include(p => p.Weights)
    //         .FirstOrDefaultAsync();
    //
    //     savedPost.ShouldNotBeNull();
    //     savedPost.Animals.ShouldContain(at => at.Id == animalType.Id);
    //     savedPost.Weights.ShouldContain(w => w.Id == weight.Id);
    // }
}