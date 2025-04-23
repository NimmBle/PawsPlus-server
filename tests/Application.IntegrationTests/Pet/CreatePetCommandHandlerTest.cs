using Bogus;
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
        // var userId = await RunAsUserAsync("owner@test.com", "Owner123!", new[] { "PetOwner" });
        
        var currentUser = Substitute.For<ICurrentUser>();
        var command = new CreatePetCommand()
        {
            ProfileId = _faker.Random.Guid().ToString(),
            PetType = 1,
            Breeds = new List<BreedInputModel>
            {
                new BreedInputModel()
                {
                    Id = "56",
                    Name = "Test"
                }
            },
            Name = _faker.Name.FirstName(),
            PhotoUrl = _faker.Internet.Url(),
            Age = new AgeInputModel()
            {
                Years = 3,
                Months = 5
            },
            Gender = Gender.Female,
            Personality = new PersonalityInputModel()
            {
                Temperament = "Friendly",
                ActivityLevel = "High",
                IsTrained = Training.No,
                HasFears = Fear.No,
                FearsDescription = ""
            },

            HealthStatus = new HealthStatusInputModel()
            {
                IsVaccinated = true,
                IsCastrated = false,
                TakesMedications = false,
                HasEatingSchedule = "yes",
                OtherDietaryNeeds = "",
                HealthProblems = ""
            },
            Weight = _faker.Random.Int(1, 4),
        };
        
        // Act
        
        var result = await Sender.Send(command);

        // Assert
        result.ShouldNotBeNull();
        result.Data.Id.ShouldNotBeNull();
    }
    
}