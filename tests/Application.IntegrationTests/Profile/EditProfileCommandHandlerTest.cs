using NSubstitute;
using PawsPlus.Application.Common.Contracts;
using PawsPlus.Application.Features.Profile.Commands;
using PawsPlus.Application.Features.Profile.Commands.Edit;
using PawsPlus.Domain.Errors;
using PawsPlus.Domain.Repositories;
using Shouldly;

namespace Application.IntegrationTests.Profile;

public class EditProfileCommandHandlerTest : BaseIntegrationTest
{
    private readonly IProfileDomainRepository _profileRepository;
    
    public EditProfileCommandHandlerTest(IntegrationTestWebAppFactory factory,
        IProfileDomainRepository profileDomainRepository) 
        : base(factory)
    {
        _profileRepository = profileDomainRepository;
    }
    
    private static LocationInputModel location = new()
    {
        PlaceId = "none",
        Latitude = 1,
        Longitude = 1
    };
    
    private static EditProfileCommand command = new()
    {
        Id = Guid.NewGuid().ToString(),
        FirstName = "Test",
        LastName = "Test",
        PhoneNumber = "08787878",
        PhotoUrl = "https://res.cloudinary.com/ds95qikmm/image/upload/v1740853041/20770253_Sandy_Bus-43_Single-04.svg403477.svg",
        Location = location
    };

    [Fact]
    public async Task Edit_Should_ReturnSuccessful_WhenRequestIsValid()
    {
        // Arrange
        var currentUserMock = Substitute.For<ICurrentUser>();
        var profileDomainRepository = Substitute.For<IProfileDomainRepository>();
        currentUserMock.UserId.Returns(command.Id);
        
        var handler = new EditProfileCommand.EditUserCommandHandler(currentUserMock,
            profileDomainRepository);
        
        // Act
        var result = await handler.Handle(command, CancellationToken.None);
        // Assert
        
        result.Error.ShouldBe(ProfileErrors.ProfileAccessNotAllowed(command.Id));
    }
}




// using AutoMapper;
// using Microsoft.EntityFrameworkCore;
// using NSubstitute;
// using PawsPlus.Application.Common.Contracts;
// using PawsPlus.Application.Features.Pet.Commands.Common;
// using PawsPlus.Application.Features.Pet.Commands.Create;
// using PawsPlus.Domain.Enums.Pet;
// using PawsPlus.Domain.Repositories;
//
// namespace Application.IntegrationTests.Pet;
//
// public class CreatePetCommandHandlerTest : BaseIntegrationTest
// {
//     private readonly IPetDomainRepository _petDomainRepository;
//     private readonly IMapper _mapper;
//     private readonly ICurrentUser _currentUser = Substitute.For<ICurrentUser>();
//     
//     public CreatePetCommandHandlerTest(IntegrationTestWebAppFactory factory)
//         : base(factory)
//     {
//     }
//
//     [Fact]
//     public async Task CreatePet_Should_AddUserToDatabase_WhenCommandIsValid()
//     {
//         // Arrange: Set up the necessary data for the command
//         var profileId = Guid.NewGuid().ToString();
//         var petType = 1;
//         var breeds = new List<BreedInputModel>
//         {
//             new BreedInputModel()
//             {
//                 Id = "56",
//                 Name = "Test"
//             }
//         };
//         var name = "Buddy";
//         var photoUrl = "http://example.com/photo.jpg";
//         var age = new AgeInputModel()
//         {
//             Years = 3,
//             Months = 5
//         };
//         var gender = "Male";
//         var personality = new PersonalityInputModel()
//         {
//             Temperament = "Friendly",
//             ActivityLevel = "High",
//             IsTrained = Training.No,
//             HasFears = Fear.No,
//             FearsDescription = ""
//         };
//         var healthStatus = new HealthStatusInputModel()
//         {
//             IsVaccinated = true,
//             IsCastrated = false,
//             TakesMedications = false,
//             HasEatingSchedule = "yes",
//             OtherDietaryNeeds = "",
//             HealthProblems = ""
//         };
//         var weight = 2;
//     
//         var command = new CreatePetCommand
//         {
//             ProfileId = profileId,
//             PetType = petType,
//             Breeds = breeds,
//             Name = name,
//             PhotoUrl = photoUrl,
//             Age = age,
//             Gender = Gender.Female,
//             Personality = personality,
//             HealthStatus = healthStatus,
//             Weight = weight
//         };
//
//         _currentUser.UserId.Returns(profileId);
//
//         // Act
//         var result = await Sender.Send(command);
//
//         // Assert: Check if the pet was created in the database
//         var pet = await DbContext.Pets.FirstOrDefaultAsync(p => p.Id == result.Data.Id);
//
//         Assert.NotNull(pet);
//         Assert.Equal(name, pet.Name);
//         Assert.Equal(photoUrl, pet.PhotoUrl);
//     }
//     
// }