using System.Transactions;
using System.Web;
using Microsoft.AspNetCore.Identity;
using PawsPlus.Application.Common;
using PawsPlus.Application.Features.Profile.Queries.Mine;
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
    
    private const string InvalidErrorMessage = "Invalid Credentials";

    public async Task<Result<MineProfileOutputModel>> GetUserProfile(string userId)
    {
        var user = await userManager.FindByIdAsync(userId);
        var roles = await userManager.GetRolesAsync(user);
        var profile = new MineProfileOutputModel()
        {
            Id = user.Profile.Id,
            Email = user.Email,
            FirstName = user.Profile.FirstName,
            LastName = user.Profile.LastName,
            Description = user.Profile.Description,
            PhoneNumber = user.Profile.PhoneNumber,
            PhotoUrl = user.Profile.PhotoUrl,
            Roles = roles, 
        };

        return profile;
    }

    public async Task<Result<IUser>> Register(string email,
        string firstName,
        string lastName,
        string password,
        string role)
    {
        var user = new User()
        {
            UserName = firstName + " " + lastName,
            Email = email
        };
        
        using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
        {
            try
            {
                var identityResult = await userManager.CreateAsync(user, password);
                var errors = identityResult.Errors.Select(e => e.Description);

                if (!identityResult.Succeeded)
                    return Result<IUser>.Failure(errors);

                var rolesResult = await userManager.AddToRoleAsync(user, role);
                var roleErrors = rolesResult.Errors.Select(e => e.Description);
                
                // _ = SendConfirmationEmail(user, userInput.FirstName, userInput.LastName);
                
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

    public async Task<Result<LoginOutputModel>> Login(LoginUserCommand userInput)
    {
        var user = await userManager.FindByEmailAsync(userInput.Email);
        if (user == null)
            return InvalidErrorMessage;

        var passwordValid = await userManager.CheckPasswordAsync(user, userInput.Password);
        if (!passwordValid)
            return InvalidErrorMessage;
        
        var userRoles = await userManager.GetRolesAsync(user);

        var token = jwtTokenGenerator.GenerateToken(user.Id, userInput.Email, userRoles);
        
        var roles = await userManager.GetRolesAsync(user);
        
        return new LoginOutputModel(user.Id, token, roles);
    }

    public async Task<Result> ChangeEmail(string userId, string newEmail)
    {
        if (await EmailAlreadyExists(newEmail))
            return "Email already exists";
        
        var user = await userManager.FindByIdAsync(userId);
        if (user == null)
            return false;

        user.Email = newEmail;
        user.NormalizedEmail = newEmail.ToUpper().Normalize();
        user.EmailConfirmed = false;
        
        user.UserName = newEmail; 
        user.NormalizedUserName = newEmail.ToUpper().Normalize();

        var identityResult = await userManager.UpdateAsync(user);

        if (!identityResult.Succeeded)
            return Result.Failure(identityResult.Errors.Select(e => e.Description));
        
        // await SendConfirmationEmail(user);
        
        return Result.Success;
    }

    // public async Task SendPasswordResetEmail(string email)
    // {
    //     var user = await userManager.FindByEmailAsync(email);
    //     var token = await userManager.GeneratePasswordResetTokenAsync(user);
    //     
    //     var apiKey = Environment.GetEnvironmentVariable("SENDGRID_API_KEY");
    //     var confirmationLink =
    //         $"http://localhost:4200/auth/confirm-email?email={email}&token={HttpUtility.UrlEncode(token)}";
    //     
    //     var client = new SendGridClient(apiKey);
    //     var from = new EmailAddress("no-reply@pawsplus.eu", "Лапички+");
    //     var subject = "Създаване на нова парола";
    //     var to = new EmailAddress(user.Email, user.UserName);
    //     var htmlContent = $@"
    //     <html>
    //     <body style='font-family: Oswald, sans-serif;'>
    //       <p>Хей!</p>
    //       <p>За да създадеш новата си парола последвай линка: <br/> <a href='{confirmationLink}'>създай нова парола </a> </p>
    //       <p>Благодарим предварително!</p>
    //       <p>Поздрави, <br/> Екипът на 'Лапички+'</p>
    //     </body>
    //     </html>";
    //     
    //     var message = MailHelper.CreateSingleEmail(from, to, subject, null, htmlContent);
    //     
    //     var result = await client.SendEmailAsync(message);
    //
    //     if (result.IsSuccessStatusCode)
    //     {
    //         Console.WriteLine("Email sent");
    //     }
    // }
    //
    // public Task<Result> ResetPassword(string email, string oldPassword, string newPassword)
    // {
    //     throw new NotImplementedException();
    // }
    //

    public async Task<bool> EmailAlreadyExists(string email)
    {
        var userExists = await userManager.FindByEmailAsync(email);

        if (userExists != null)
            return true;

        return false;
    }

    public async Task<Result> ConfirmEmail(string userid, string token)
    {
        var user = await userManager.FindByIdAsync(userid);

        if (user == null)
            return "User not found";
        
        var isVerified = await userManager.IsEmailConfirmedAsync(user);

        if (isVerified)
            return "Email is already confirmed";
        
        var decodedToken = HttpUtility.UrlDecode(token);
        var result = await userManager.ConfirmEmailAsync(user, decodedToken);

        if (!result.Succeeded)
            return "Email confirmation failed";

        return Result.Success;
    }

    public async Task<IList<string>> GetRoles(string userId)
    {
        var user = await userManager.FindByIdAsync(userId);
        
        var roles = await userManager.GetRolesAsync(user);

        return roles;
    }


    public async Task SendConfirmationEmail(User user, string firstName = "", string lastName = "")
    {
        // var apiKey = "REDACTED_SENDGRID_API_KEY";
        var apiKey = Environment.GetEnvironmentVariable("SENDGRID_API_KEY");
        var token = await userManager.GenerateEmailConfirmationTokenAsync(user);
        var confirmationLink =
            $"http://localhost:4200/auth/confirm-email?userId={user.Id}&token={HttpUtility.UrlEncode(token)}";
        
        var client = new SendGridClient(apiKey);
        var from = new EmailAddress("no-reply@pawsplus.eu", "Лапички+");
        var subject = "Потвърждаване на имейл адрес";
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
        
         client.SendEmailAsync(message);
    }
}
