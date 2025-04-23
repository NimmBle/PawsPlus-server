using NSubstitute;
using PawsPlus.Application.Common.Contracts;
using PawsPlus.Application.Features.Profile.Commands;
using PawsPlus.Application.Features.Profile.Commands.Edit;
using PawsPlus.Domain.Errors;
using PawsPlus.Domain.Repositories;

using Shouldly;

namespace Application.UnitTests.Profile.Commands;

public class EditProfileCommandHandlerTest
{
    private static LocationInputModel location = new()
    {
        PlaceId = "none",
        Latitude = 1,
        Longitude = 1
    };

    private static EditProfileCommand command = new()
    {
        Id = "1",
        FirstName = "Test",
        LastName = "Test",
        PhoneNumber = "08787878",
        PhotoUrl = "https://res.cloudinary.com/ds95qikmm/image/upload/v1740853041/20770253_Sandy_Bus-43_Single-04.svg403477.svg",
        Location = location
    };
    

    [Fact]
    public async Task EditProfileCommandHandler_Should_ReturnError_WhenProfileIsNull()
    {
        // Assert
        var currentUserMock = Substitute.For<ICurrentUser>();
        var profileDomainRepository = Substitute.For<IProfileDomainRepository>();
        var profile = new PawsPlus.Domain.Models.Profile("First", "Last", "0878787878");
        
        var handler = new EditProfileCommand.EditUserCommandHandler(currentUserMock,
            profileDomainRepository);
        
        currentUserMock.UserId.Returns(command.Id);
                
        profileDomainRepository
            .FindByUser(currentUserMock.UserId, default)
            .Returns(null as PawsPlus.Domain.Models.Profile);
        
        // Act
        var result = await handler.Handle(command, default);
        
        // Arrange
        result.Error.ShouldBe(ProfileErrors.ProfileNotFound(currentUserMock.UserId));
    }
    
    [Fact]
    public async Task EditProfileCommandHandler_Should_ReturnError_WhenRequestIdIsDifferentFromCurrentUserId()
    {
        // Assert
        var currentUserMock = Substitute.For<ICurrentUser>();
        var profileDomainRepository = Substitute.For<IProfileDomainRepository>();
        var profile = new PawsPlus.Domain.Models.Profile("First", "Last", "0878787878");
        
        var handler = new EditProfileCommand.EditUserCommandHandler(currentUserMock,
            profileDomainRepository);
        
        currentUserMock.UserId.Returns(command.Id);
        
        profileDomainRepository
            .FindByUser(currentUserMock.UserId, default)
            .Returns(profile);
        
        // Act
        var result = await handler.Handle(command, default);
        
        // Arrange
        result.Error.ShouldBe(ProfileErrors.ProfileAccessNotAllowed(command.Id));
    }

    [Fact]
    public async Task EditProfileCommandHandler_Should_ReturnSuccess_WhenRequestIdIsValid()
    {
        // Assert
        var currentUserMock = Substitute.For<ICurrentUser>();
        var profileDomainRepository = Substitute.For<IProfileDomainRepository>();

        var profile = new PawsPlus.Domain.Models.Profile("First", "Last", "0878787878");
        profile.Id = command.Id;
        
        var handler = new EditProfileCommand.EditUserCommandHandler(currentUserMock,
            profileDomainRepository);
        
        currentUserMock.UserId.Returns(profile.Id);
        
        profileDomainRepository
            .FindByUser(profile.Id)
            .Returns(profile);
        
        // Act
        var result = await handler.Handle(command, default);
        
        // Arrange
        result.Succeeded.ShouldBeTrue();
    }
}