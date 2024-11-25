using System.Transactions;
using Microsoft.AspNetCore.Identity;
using Zoolandia.Application.Common;
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
        
        using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
        {
            try
            {
                var identityResult = await userManager.CreateAsync(user, userInput.Password);
                var errors = identityResult.Errors.Select(e => e.Description);

                if (!identityResult.Succeeded)
                    return Result<IUser>.Failure(errors);

                var rolesResult = await userManager.AddToRoleAsync(user, Enum.GetName(userInput.Role));
                var roleErrors = rolesResult.Errors.Select(e => e.Description);
                
                scope.Complete();
                
                return rolesResult.Succeeded
                    ? Result<IUser>.SuccessWith(user)
                    : Result<IUser>.Failure(roleErrors);
                
            }
            catch (Exception ex)
            {
                scope.Dispose();
                throw ex;
            }
            
        }

        // confirm email

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

    public async Task<Result> ChangeEmail(string userId, string newEmail)
    {
        var user = await userManager.FindByIdAsync(userId);
        if (user == null)
            return false;

        var normalizedEmail = newEmail.ToUpper().Normalize();

        user.Email = newEmail;
        user.NormalizedEmail = normalizedEmail;
        user.EmailConfirmed = false;
        
        user.UserName = newEmail;
        user.NormalizedUserName = normalizedEmail;

        var identityResult = await userManager.UpdateAsync(user);

        if (!identityResult.Succeeded)
            return Result.Failure(identityResult.Errors.Select(e => e.Description));
        
        // send confirmation email
        
        return Result.Success;
    }
    
}
