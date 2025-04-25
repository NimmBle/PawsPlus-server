using Bogus;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
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

    private readonly Faker _faker = new();
    
    public EditProfileCommandHandlerTest(IntegrationTestWebAppFactory factory) 
        : base(factory)
    {
    }
    
    [Fact]
    public async Task Edit_Should_ReturnError_WhenTryingToEditAnotherProfile()
    {
        // Arrange
        var ids = await CreateTestUser();
        var sender = await ConfigureCurrentUser(ids.UserId, ids.ProfileId);
        var location = new LocationInputModel()
        {
            PlaceId = "none",
            Latitude = _faker.Random.Double(-90, 90),
            Longitude = _faker.Random.Double(-180, 180),
        };
        
        var command = new EditProfileCommand()
        {
            Id = Guid.NewGuid().ToString(),
            FirstName = _faker.Name.FirstName(),
            LastName = _faker.Name.LastName(),
            PhoneNumber = _faker.Phone.PhoneNumber("##########"),
            PhotoUrl = _faker.Internet.Url(),
            Location = location
        };
        
        // Act
        var result = await sender.Send(command, CancellationToken.None);
        // Assert

        result.Succeeded.ShouldBeFalse();
        result.Error.ShouldBe(ProfileErrors.ProfileAccessNotAllowed(command.Id));
    }
    
    [Fact]
    public async Task Edit_Should_ReturnSuccessful_WhenRequestIsValid()
    {
        // Arrange
        var ids = await CreateTestUser();
        var sender = await ConfigureCurrentUser(ids.UserId, ids.ProfileId);
        var location = new LocationInputModel()
        {
            PlaceId = "none",
            Latitude = _faker.Random.Double(-90, 90),
            Longitude = _faker.Random.Double(-180, 180),
        };
        
        var command = new EditProfileCommand()
        {
            Id = ids.ProfileId,
            FirstName = _faker.Name.FirstName(),
            LastName = _faker.Name.LastName(),
            PhoneNumber = _faker.Phone.PhoneNumber("##########"),
            PhotoUrl = _faker.Internet.Url(),
            Location = location
        };
        
        // Act
        var result = await sender.Send(command, CancellationToken.None);
        // Assert

        result.Succeeded.ShouldBeTrue();
        var profile = DbContext.Profiles.SingleOrDefault(p => p.Id == ids.ProfileId);
        profile.ShouldNotBeNull();
        profile.FirstName.ShouldBe(command.FirstName);
        profile.LastName.ShouldBe(command.LastName);
        profile.PhoneNumber.ShouldBe(command.PhoneNumber);
        profile.PhotoUrl.ShouldBe(command.PhotoUrl);
        profile.Location.PlaceId.ShouldBe(command.Location.PlaceId);
        profile.Location.Point.X.ShouldBe(command.Location.Latitude);
        profile.Location.Point.Y.ShouldBe(command.Location.Longitude);
    }
}