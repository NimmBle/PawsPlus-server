using Microsoft.AspNetCore.Identity;
using Zoolandia.Applicaiton.Identity;
using Zoolandia.Applicaiton.Identity.Commands;
using Zoolandia.Application.Common;

namespace Zoolandia.Infrastructure.Identity;

internal class IdentityService(UserManager<User> userManager) : IIdentity
{
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
        // change to Result<TData>

        return identityResult.Succeeded
            ? Result<User>.SuccessWith(user)
            : Result<User>.Failure(errors);
    }
}
