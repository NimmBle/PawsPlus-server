using System.Runtime.CompilerServices;
using System.Transactions;
using Microsoft.AspNetCore.Identity;
using PawsPlus.Application.Common;
using PawsPlus.Application.Identity;
using PawsPlus.Application.Identity.Commands.LoginUser;
using PawsPlus.Domain.Services;

[assembly: InternalsVisibleTo("Infrastructure.UnitTests")]
namespace PawsPlus.Infrastructure.Identity;

public class IdentityService(IEmailSender emailSender,
        UserManager<User> userManager,
        IJwtTokenGenerator jwtTokenGenerator)
    : IIdentity
{
    
    
    public async Task<Result<IUser>> Register(string email,
        string firstName,
        string lastName,
        string password,
        string role)
    {
        var user = new User()
        {
            UserName = email,
            Email = email
        };

        using var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
        try
        {
            var identityResult = await userManager.CreateAsync(user, password);
            if (!identityResult.Succeeded)
            {
                var error = identityResult.Errors.Select(e => e.Description).First();
                return IdentityErrors.IdentityError(error);
            }
                
            var rolesResult = await userManager.AddToRoleAsync(user, role);
            if (!rolesResult.Succeeded)
            {
                var roleError = rolesResult.Errors.Select(e => e.Description).First();
                return IdentityErrors.IdentityError(roleError);
            }
                
            var sendGridResponse = await emailSender.SendConfirmationEmail(user.Id, firstName, lastName);
            if (!sendGridResponse)
            {
                return IdentityErrors.IdentityError("Не успяхме да изпраим имейл. Моля, опитайте след малко");
            }
                
            scope.Complete();

            return Result<IUser>.SuccessWith(user);
        }
        catch (Exception ex)
        {
            scope.Dispose();
            throw ex;
        }
    }

    public async Task<Result<LoginOutputModel>> Login(LoginUserCommand userInput)
    {
        var user = await userManager.FindByEmailAsync(userInput.Email);
        if (user == null)
        {
            return IdentityErrors.InvalidCredentials;
        }
        
        if (!user.EmailConfirmed)
        {
            return IdentityErrors.EmailNotConfirmed;    
        }
            
        var passwordValid = await userManager.CheckPasswordAsync(user, userInput.Password);
        if (!passwordValid)
        {
            return IdentityErrors.InvalidCredentials;
        }
            
        var userRoles = await userManager.GetRolesAsync(user);
        var token = jwtTokenGenerator.GenerateToken(user.Id, userInput.Email, userRoles);
        
        var roles = await userManager.GetRolesAsync(user);
        
        return new LoginOutputModel(user.Id, token, roles);
    }

    public async Task<Result> ChangeEmail(string userId, string newEmail)
    {
        if (await EmailAlreadyExists(newEmail))
        {
            return IdentityErrors.EmailNotUnique;
        }
        
        var user = await userManager.FindByIdAsync(userId);
        if (user == null)
        {
            return IdentityErrors.UserNotFound(userId);
        }
    
        user.Email = newEmail;
        user.NormalizedEmail = newEmail.ToUpper().Normalize();
        user.EmailConfirmed = false;
        
        user.UserName = newEmail; 
        user.NormalizedUserName = newEmail.ToUpper().Normalize();
    
        var identityResult = await userManager.UpdateAsync(user);
        if (!identityResult.Succeeded)
        {
            return IdentityErrors.EmailChangeFailed;
        }
        
        await emailSender.SendConfirmationEmail(user.Id);
        
        return Result.Success;
    }

    public async Task<Result> SendPasswordResetEmail(string userId)
    {
        var user = await userManager.FindByIdAsync(userId);
        var token = await userManager.GeneratePasswordResetTokenAsync(user);

        // var sendGridResponse = await emailSender.SendPasswordResetEmail(user.Id, user.Email, token);
        // if (!sendGridResponse)
        // {
        //     return IdentityErrors.IdentityError("Не успяхме да изпратим имейл. Моля, опитайте след малко");
        // }
        
        return Result.Success;

    }

    public async Task<Result> ResetPassword(string userId, string token, string newPassword)
    {
        var user = await userManager.FindByIdAsync(userId);
        var result = await userManager.ResetPasswordAsync(user, token, newPassword);

        if (!result.Succeeded)
        {
            return IdentityErrors.IdentityError("Новата парола не беше запазена. Моля, опитайте след малко.");
        }
        return result.Succeeded;
    }

    public async Task<Result> ChangePassword(string email,
        string currentPassword,
        string newPassword)
    {
        var user = await userManager.FindByEmailAsync(email);

        var result = await userManager.ChangePasswordAsync(user, currentPassword, newPassword);

        if (!result.Succeeded)
        {
            return IdentityErrors.PasswordChangeFailed;
        }
        
        return Result.Success;
    }

    public async Task<Result> ConfirmEmail(string userId,
        string token)
    {
        var user = await userManager.FindByIdAsync(userId);
        if (user == null)
        {
            return IdentityErrors.UserNotFound(userId);
        }
        
        var isVerified = await userManager.IsEmailConfirmedAsync(user);
        if (isVerified)
        {
            return IdentityErrors.EmailAlreadyConfirmed(user.Email);
        }
        
        var result = await userManager.ConfirmEmailAsync(user, token);
        if (!result.Succeeded)
        {
            return IdentityErrors.EmailConfirmationFailed(user.Email);
        }

        return Result.Success;
    }

    public async Task<IList<string>> GetRoles(string userId)
    {
        var user = await userManager.FindByIdAsync(userId);
        
        var roles = await userManager.GetRolesAsync(user);

        return roles;
    }

    public async Task<string> GetEmail(string userId)
    {
        var user = await userManager.FindByIdAsync(userId);
        
        var email = await userManager.GetEmailAsync(user);

        return email;
    }

    private async Task<bool> EmailAlreadyExists(string email)
    {
        var user = await userManager.FindByEmailAsync(email);
        return user != null;
    }
}
