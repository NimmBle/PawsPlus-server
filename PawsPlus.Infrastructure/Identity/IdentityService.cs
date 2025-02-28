using System.Transactions;
using System.Web;
using Microsoft.AspNetCore.Identity;
using PawsPlus.Application.Common;
using PawsPlus.Application.Identity;
using PawsPlus.Application.Identity.Commands.LoginUser;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace PawsPlus.Infrastructure.Identity;

internal class IdentityService(
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
                
            var sendGridResponse = await SendConfirmationEmail(user, firstName, lastName);
            if (!sendGridResponse.IsSuccessStatusCode)
            {
                return IdentityErrors.IdentityError("Unable to send a confirmation email. Please try registering again.");
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

    // public async Task<Result> ChangeEmail(string userId, string newEmail)
    // {
    //     if (await EmailAlreadyExists(newEmail))
    //     {
    //         return IdentityErrors.EmailNotUnique;
    //     }
    //     
    //     var user = await userManager.FindByIdAsync(userId);
    //     if (user == null)
    //     {
    //         return IdentityErrors.UserNotFound(userId);
    //     }
    //
    //     user.Email = newEmail;
    //     user.NormalizedEmail = newEmail.ToUpper().Normalize();
    //     user.EmailConfirmed = false;
    //     
    //     user.UserName = newEmail; 
    //     user.NormalizedUserName = newEmail.ToUpper().Normalize();
    //
    //     var identityResult = await userManager.UpdateAsync(user);
    //     if (!identityResult.Succeeded)
    //     {
    //         return IdentityErrors.EmailChangeFailed;
    //     }
    //     
    //     // await SendConfirmationEmail(user);
    //     
    //     return Result.Success;
    // }
    
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

    public async Task<Response> SendConfirmationEmail(User user,
        string firstName = "",
        string lastName = "")
    {
        var apiKey = Environment.GetEnvironmentVariable("SENDGRID_API_KEY");
        var token = await userManager.GenerateEmailConfirmationTokenAsync(user);
        var confirmationLink =
            $"http://localhost:4200/auth/confirm-email?userId={user.Id}&token={HttpUtility.UrlEncode(token)}";
        
        var client = new SendGridClient(apiKey);
        var from = new EmailAddress("no-reply@pawsplus.eu", "Екипът на Лапички+");
        var subject = "Лапички+ - Потвърждаване на имейл адрес";
        var to = new EmailAddress(user.Email, user.UserName);
        var htmlContent = $@"
        <html>
        <body style='font-family: Oswald, sans-serif;'>
          <p>Хей, { firstName } { lastName }!</p>
          <p>Нека направим този имейл адрес официален - само трябва да потвърдиш, че си ти.</p>
          <p>
            Не се колебай, последвай връзката: <br/> <a href='{confirmationLink}'>потвърди имейл</a>
          </p>
          <p>Благодарим предварително!</p>
          <p>Поздрави, <br/> Екипът на 'Лапички+'</p>
        </body>
        </html>";
        
        var message = MailHelper.CreateSingleEmail(from, to, subject, null, htmlContent);
        
        return await client.SendEmailAsync(message);
        
        
    }
}
