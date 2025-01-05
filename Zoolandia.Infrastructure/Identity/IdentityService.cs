using System.Transactions;
using System.Web;
using Microsoft.AspNetCore.Identity;
using SendGrid;
using SendGrid.Helpers.Mail;
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
                
                // await SendConfirmationEmail(user);
                
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
        
        var roles = await userManager.GetRolesAsync(user);

        return new LoginSuccessModel(user.Id, token, roles);
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

    public async Task<bool> EmailAlreadyExists(string email)
    {
        var userExists = await userManager.FindByEmailAsync(email);

        if (userExists != null)
            return true;

        return false;
    }

    public async Task<Result> ConfirmEmail(string id, string token)
    {
        var user = await userManager.FindByIdAsync(id);

        if (user == null)
            return "User not found";
        
        var isVerified = await userManager.IsEmailConfirmedAsync(user);

        if (isVerified)
            return "Email is already confirmed";
        
        var result = await userManager.ConfirmEmailAsync(user, token);

        if (!result.Succeeded)
            return "Email confirmation failed";

        return Result.Success;
    }
    

    // public async Task SendConfirmationEmail(User user)
    // {
    //     var apiKey = "REDACTED_SENDGRID_API_KEY";
    //     // var apiKey = Environment.GetEnvironmentVariable("SendGrid-ApiKey");
    //     var token = await userManager.GenerateEmailConfirmationTokenAsync(user);
    //     var confirmationLink =
    //         $"http://localhost:4200/auth/confirm-email?userId={user.Id}&token={HttpUtility.UrlEncode(token)}";
    //     
    //     var client = new SendGridClient(apiKey);
    //     var from = new EmailAddress("pawspluswebapp@gmail.com", "PawsPlus");
    //     var subject = "Потвърждаване на имейл адрес";
    //     var to = new EmailAddress(user.Email, user.UserName);
    //     var htmlContent = $@"
    //     <html>
    //     <body style='font-family: Oswald, sans-serif;'>
    //       <p>Хей, {user.UserName}!</p>
    //       <p>Нека направим този имейл адрес официален - само трябва да потвърдиш, че си ти.</p>
    //       <p>
    //         Не се колебай, последвай връзката: <br/> <a href='{confirmationLink}'>потвърди имейл</a>
    //       </p>
    //       <p>Благодарим предварително!</p>
    //       <p>Поздрави, <br/> Екипът на Умелико</p>
    //     </body>
    //     </html>";
    //     
    //     var message = MailHelper.CreateSingleEmail(from, to, subject, null, htmlContent);
    //     
    //     await client.SendEmailAsync(message);
    // }
}
