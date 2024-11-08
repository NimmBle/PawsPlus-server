using Microsoft.AspNetCore.Identity;
using Zoolandia.Applicaiton.Identity;
using Zoolandia.Applicaiton.Identity.Commands.CreateUser;
using Zoolandia.Applicaiton.Identity.Commands.LoginUser;
using Zoolandia.Application.Common;

namespace Zoolandia.Infrastructure.Identity;

internal class IdentityService(
        UserManager<User> userManager,
        IJwtTokenGenerator jwtTokenGenerator)
    : IIdentity
{
    private const string InvalidErrorMessage = "Invalid Credentials";
    public async Task<Result> Register(CreateUserCommand userInput)
    {
        var user = new User()
        {
            UserName = userInput.Email,
            Email = userInput.Email,
            Profile = new()
            {
                FirstName = userInput.FirstName,
                LastName = userInput.LastName
            }
        };

        var identityResult = await userManager.CreateAsync(user, userInput.Password);

        var errors = identityResult.Errors.Select(e => e.Description);
        
        // confirmation email

        return identityResult.Succeeded
            ? Result<User>.SuccessWith(user)
            : Result<User>.Failure(errors);
    }

    public async Task<Result<LoginSuccessModel>> Login(LoginUserCommand userInput)
    {
        var user = await userManager.FindByEmailAsync(userInput.Email);
        if (user == null)
            return InvalidErrorMessage;

        var passwordValid = await userManager.CheckPasswordAsync(user, userInput.Password);
        if (!passwordValid)
            return InvalidErrorMessage;

        var token = jwtTokenGenerator.GenerateToken(user.Id, userInput.Email);

        return new LoginSuccessModel(token);
    }
}
