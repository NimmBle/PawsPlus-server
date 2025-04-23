using PawsPlus.Domain.Common;
using PawsPlus.Domain.Exceptions;
using PawsPlus.Domain.Models;
using PawsPlus.Domain.ValueObjects;
using Shouldly;
using Xunit.Abstractions;

namespace Domain.UnitTests;

public class ProfileTests
{
    private Profile profile = new("First", "Last", "0878787878");
    private readonly ITestOutputHelper _testOutputHelper;
    
    public ProfileTests(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
        profile.UpdateDescription("Initial description");
        profile.UpdateLocation("initPlace", 42.0, 23.0);
        profile.UpdatePhotoUrl(
            "https://res.cloudinary.com/ds95qikmm/image/upload/v1740853041/20770253_Sandy_Bus-43_Single-04.svg403477.svg");

    }

    [Theory()]
    [InlineData("")]
    [InlineData("a")]
    [InlineData("FirstNameThatIsMoreThan20CharactersLong")]
    public async Task FirstNameUpdate_Should_ThrowException_WhenFirstNameIsEmpty(string newName)
    {
        Should.Throw<InvalidProfileException>(() => profile.UpdateFirstName(newName));
    }

    [Theory()]
    [InlineData("Test")]
    [InlineData("ТестовоИме")]
    [InlineData("TestName232")]
    public async Task FirstNameUpdate_Should_Update_WhenItIsValid(string newName)
    {
        // Act
        profile.UpdateFirstName(newName);
        
        // Assert
        profile.FirstName.ShouldBe(newName);
    }
    
    
    
    [Theory]
    [InlineData("")]
    [InlineData("notaurl")]
    [InlineData("http//missing-colon.com")]
    public void PhotoUrlUpdate_Should_ThrowException_WhenUrlIsInvalid(string url)
    {
        Should.Throw<InvalidProfileException>(() => profile.UpdatePhotoUrl(url));
    }

    [Theory]
    [InlineData("http://example.com/a.png")]
    [InlineData("https://cdn.site.com/photo.jpeg")]
    public void PhotoUrlUpdate_Should_Update_WhenUrlIsValid(string url)
    {
        profile.UpdatePhotoUrl(url);
        
        profile.PhotoUrl.ShouldBe(profile.PhotoUrl);
    }
    
    
    
    [Theory]
    [InlineData("")]
    [InlineData("123")]
    [InlineData("12345678901234567890")]
    public void PhoneNumberUpdate_Should_ThrowException_WhenNumberIsInvalid(string number)
    {
        Should.Throw<InvalidProfileException>(() => profile.UpdatePhoneNumber(number));
    }

    [Theory]
    [InlineData("0888123455")]
    [InlineData("+359878788")]
    [InlineData("0898989898")]
    public void PhoneNumberUpdate_Should_Update_WhenNumberIsValid(string number)
    {
        profile.UpdatePhoneNumber(number);

        profile.PhoneNumber.ShouldBe(number);
    }
    
    
    
    [Fact]
    public void DescriptionUpdate_Should_DoNothing_WhenNullPassed()
    {
        var current = profile.Description;

        profile.UpdateDescription(null);

        profile.Description.ShouldBe(current);
    }
    
    [Theory]
    [InlineData("Short")]
    [InlineData("Това е валидно описание")]
    public void DescriptionUpdate_Should_Update_WhenValid(string text)
    { 
        profile.UpdateDescription(text);

        profile.Description.ShouldBe(text);
    }
    
    [Theory]
    [InlineData("newPlace", 43.1234, 25.9876)]
    [InlineData("ChIJd8BlQ2BZwokRAFUEcm_qrcA", 40.7128, -74.0060)]
    public void LocationUpdate_Should_Update_AllFields(string placeId, double lat, double lng)
    {
        var location = new Location(placeId, lat, lng);
        
        profile.UpdateLocation(placeId, lat, lng);

        profile.Location.PlaceId.ShouldBe(placeId);
        profile.Location.Point.X.ShouldBe(lat);
        profile.Location.Point.Y.ShouldBe(lng);
    }
    
    
    [Fact]
    public void FirstLoginUpdate_Should_SetFlagToFalse()
    { 
        profile.FirstLogin.ShouldBeTrue();

        profile.UpdateFirstLogin();

        profile.FirstLogin.ShouldBeFalse();
    }
}