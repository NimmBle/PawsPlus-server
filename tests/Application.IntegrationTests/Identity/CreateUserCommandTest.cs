using Bogus;
using CloudinaryDotNet.Actions;
using PawsPlus.Application.Identity.Commands.CreateUser;
using Shouldly;

namespace Application.IntegrationTests.Identity;

public class CreateUserCommandTest : BaseIntegrationTest
{

    private readonly Faker _faker = new();
    public CreateUserCommandTest(IntegrationTestWebAppFactory factory) 
        : base(factory)
    {
    }

    [Fact]
    public async Task CreateUser_Should_AddUserToDb_WhenDataIsValid()
    {
        // arrange
        var email = _faker.Internet.Email();
        var command = new CreateUserCommand()
        {
            Email = email,
            FirstName = _faker.Name.FirstName(),
            LastName = _faker.Name.LastName(),
            Password = _faker.Internet.Password(),
            PhoneNumber = _faker.Phone.PhoneNumber("##########"),
            Role = _faker.PickRandom<PawsPlus.Domain.Enums.Role>()
        };
        
        // act
        var result = await Sender.Send(command);
        
        // assert
        result.ShouldNotBeNull();
        var user = DbContext.Users.FirstOrDefault(u => u.Email == email);
        user.ShouldNotBeNull();
    }
}