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

    public CreatePostCommandHandlerTest(IntegrationTestWebAppFactory factory) 
        : base(factory)
    {
    }

    [Fact]
    public async Task CreatePost_WithValidData_ShouldSucceed()
    {
        // Arrange
        var ids = await CreateTestUser();
        List<int> pets = new List<int>() { _faker.Random.Int(1, 2) };
        List<int> weight  = new List<int>() { _faker.Random.Int(1, 4) };
        
        var command = new CreatePostCommand
        {
            profileId = ids.ProfileId,
            Services = new List<ServiceType> { _faker.Random.Enum<ServiceType>() },
            Pets = pets,
            Weights = weight
        };

        // Act
        var result = await Sender.Send(command);

        // Assert
        result.Succeeded.ShouldBeTrue();
        
        var savedPost = await DbContext.Posts
            .Where(p => p.ProfileId == ids.ProfileId)
            .Include(p => p.Animals)
            .Include(p => p.Weights)
            .FirstOrDefaultAsync();

        savedPost.ShouldNotBeNull();
        savedPost.Animals.ShouldContain(at => at.Id == pets.First());
        savedPost.Weights.ShouldContain(w => w.Id == weight.First());
    }
}