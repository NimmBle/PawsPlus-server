using Microsoft.AspNetCore.Identity;
using Zoolandia.Application.Common;
using Zoolandia.Application.Common.Contracts;
using Zoolandia.Application.Identity;
using Zoolandia.Application.Identity.Commands.CreateUser;
using Zoolandia.Application.Identity.Commands.LoginUser;
using Zoolandia.Domain.Models;

namespace Zoolandia.Infrastructure.Identity;

internal class IdentityService(
        UserManager<User> userManager,
        IJwtTokenGenerator jwtTokenGenerator)
    : IIdentity
{
    
    private const string InvalidErrorMessage = "Invalid Credentials";
    
    public async Task<Result<IUser>> Register(CreateUserCommand userInput)
    {
        var user = new User()
        {
            UserName = userInput.Email,
            Email = userInput.Email,
        };

        var identityResult = await userManager.CreateAsync(user, userInput.Password);
        var errors = identityResult.Errors.Select(e => e.Description);

        if (!identityResult.Succeeded)
            return Result<IUser>.Failure(errors);
        
        var rolesResult = await userManager.AddToRoleAsync(user, userInput.Role);
        var roleErrors = rolesResult.Errors.Select(e => e.Description);

        // confirm email

        return rolesResult.Succeeded
            ? Result<IUser>.SuccessWith(user)
            : Result<IUser>.Failure(roleErrors);
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

        return new LoginSuccessModel(user.Id, token);
    }
    
}
