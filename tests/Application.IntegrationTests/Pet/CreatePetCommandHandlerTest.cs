using System.Security.Claims;
using Bogus;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using NSubstitute;
using PawsPlus.Application.Common.Contracts;
using PawsPlus.Application.Features.Pet.Commands.Common;
using PawsPlus.Application.Features.Pet.Commands.Create;
using PawsPlus.Domain.Enums.Pet;
using PawsPlus.Domain.Factories.Pet;
using PawsPlus.Domain.Repositories;
using PawsPlus.Web.Services;
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
        var profileId = await CreateTestUserAsync();
        
        
        var command = new CreatePetCommand()
        {
            ProfileId = profileId,
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
        var currentUserMock = Substitute.For<ICurrentUser>();
        var profileDomainRepoMock = Substitute.For<IProfileDomainRepository>();
        var petDomainRepositoryMock = Substitute.For<IPetDomainRepository>();
        var breedDomainRepository = Substitute.For<IBreedDomainRepository>();
        var animalTypeDomainRepository = Substitute.For<IAnimalTypeDomainRepository>();
        var weightDomainRepository = Substitute.For<IWeightDomainRepository>();
        var petFactory = Substitute.For<IPetFactory>();
        currentUserMock.UserId.Returns(profileId);
        var handler = new CreatePetCommand.CreatePetCommandHandler(currentUserMock,
            profileDomainRepoMock,
            petDomainRepositoryMock,
            breedDomainRepository,
            animalTypeDomainRepository,
            weightDomainRepository,
            petFactory
        );
        // Act
        
        var result = await handler.Handle(command, CancellationToken.None);

        // Assert
        result.ShouldNotBeNull();
        result.Data.Id.ShouldNotBeNull();
        result.Succeeded.ShouldBeTrue();
    }
    
}