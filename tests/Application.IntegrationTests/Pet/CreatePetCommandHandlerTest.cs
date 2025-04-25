using Bogus;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using NSubstitute;
using PawsPlus.Application.Common.Contracts;
using PawsPlus.Application.Features.Pet.Commands.Common;
using PawsPlus.Application.Features.Pet.Commands.Create;
using PawsPlus.Domain.Enums.Pet;
using Shouldly;

namespace Application.IntegrationTests.Pet;

public class CreatePetCommandHandlerTest : BaseIntegrationTest
{
    private readonly Faker _faker = new();
    
    public CreatePetCommandHandlerTest(IntegrationTestWebAppFactory factory)
        : base(factory)
    {
    }

    [Fact]
    public async Task CreatePet_Should_AddUserToDatabase_WhenCommandIsValid()
    {
        // Arrange
        var factory = new IntegrationTestWebAppFactory();
        var ids = await CreateTestUser();
        var currentUserMock = Substitute.For<ICurrentUser>();
        currentUserMock.UserId.Returns(ids.UserId);
        factory.CurrentUserMock = currentUserMock;
        
        using var scope = factory.Services.CreateScope();
        var sender = scope.ServiceProvider.GetRequiredService<IMediator>();
        
        var command = new CreatePetCommand()
        {
            ProfileId = ids.ProfileId,
            PetType = _faker.Random.Int(1, 2),
            Breeds = new List<BreedInputModel>
            {
                new()
                {
                    Id = "56",
                    Name = "Test"
                }
            },
            Name = _faker.Name.FirstName(),
            PhotoUrl = _faker.Internet.Url(),
            Age = new AgeInputModel()
            {
                Years = _faker.Random.Int(1, 20),
                Months = _faker.Random.Int(1, 12),
            },
            Gender = Gender.Female,
            Personality = new PersonalityInputModel()
            {
                Temperament = _faker.Lorem.Sentence(2),
                ActivityLevel = _faker.Lorem.Sentence(1),
                IsTrained = Training.No,
                HasFears = Fear.No,
                FearsDescription = _faker.Lorem.Sentence(10)
            },

            HealthStatus = new HealthStatusInputModel()
            {
                IsVaccinated = _faker.Random.Bool(),
                IsCastrated = _faker.Random.Bool(),
                TakesMedications = _faker.Random.Bool(),
                HasEatingSchedule = _faker.Lorem.Sentence(20),
                OtherDietaryNeeds = _faker.Lorem.Sentence(25),
                HealthProblems = _faker.Lorem.Sentence(25)
            },
            Weight = _faker.Random.Int(1, 4),
        };
        // Act
        
        var result = await sender.Send(command, CancellationToken.None);

        // Assert
        result.ShouldNotBeNull();
        result.Data.Id.ShouldNotBeNull();
        result.Succeeded.ShouldBeTrue();
    }
    
}