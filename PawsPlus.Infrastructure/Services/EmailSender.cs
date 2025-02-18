using Microsoft.AspNetCore.Identity;
using PawsPlus.Application.Features.Profile;
using PawsPlus.Domain.Repositories;
using PawsPlus.Domain.Services;
using PawsPlus.Infrastructure.Identity;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace PawsPlus.Infrastructure.Services;

public class EmailSender(UserManager<User> userManager,
    IProfileDomainRepository profileDomainRepository,
    IProfileQueryRepository profileQueryRepository)
    : IEmailSender
{
    public async Task<bool> SendRequestEmail(string sitterId, string? meetingPlaceLocation, CancellationToken cancellationToken = default)
    {
        var sitter = await userManager.FindByIdAsync(sitterId);
        
        var apiKey = Environment.GetEnvironmentVariable("SENDGRID_API_KEY");
        var profileNotificationsLink = "http://localhost:4200/my-profile-details/notifications";
        
        
        var client = new SendGridClient(apiKey);
        var from = new EmailAddress("no-reply@pawsplus.eu", "Лапички+");
        var subject = "Лапички+ - Имате нова заявка";
        var to = new EmailAddress(sitter.Email, sitter.UserName);
        var htmlContent = $@"
        <html>
        <body style='font-family: Oswald, sans-serif;'>
          <p>Здравейте!</p>
          <p>Имате нова заявка от {sitter.UserName}</p>
          <p>
            За да видите повече детайли относно заявка, както и да я одобрите или откажете, вижте профила си в Лапички+ - <a href={profileNotificationsLink}>Отвори профил</a>
          </p>
          <p>Поздрави, <br/> Екипът на 'Лапички+'</p>
        </body>
        </html>";

//         if (meetingPlaceLocation == null)
//         {
//             htmlContent = $@"
// "
//         }
        
        var message = MailHelper.CreateSingleEmail(from, to, subject, null, htmlContent);

        var result = await client.SendEmailAsync(message);

        return result.IsSuccessStatusCode;
    }

    public async Task<bool> SendPostApproveEmail(string sitterId, CancellationToken cancellationToken = default)
    {
        var userId = await profileQueryRepository.GetUserIdByProfileId(sitterId);
        var sitter = await userManager.FindByIdAsync(userId);
        
        var apiKey = Environment.GetEnvironmentVariable("SENDGRID_API_KEY");
        var myProfilePostPage = "https://localhost:4200/my-profile-details/notifications"; // fix link
        
        var client = new SendGridClient(apiKey);
        var from = new EmailAddress("no-reply@pawsplus.eu", "Лапички+");
        var subject = "Лапички+ - Имате нова заявка";
        var to = new EmailAddress(sitter.Email, sitter.UserName);
        var htmlContent = $@"
        <html>
        <body style='font-family: Oswald, sans-serif;'>
            <p>Привет, {sitter.UserName}!</p>
            <p>Добри новини - твоят профил в Лапички+ е <b>одобрен</b>. Това го прави услугите, които предлагаш, достъпни за всички!</p>
            <p>Можеш да завършиш напълно своите услуги, чрез тази връзка - <a href={myProfilePostPage}> Отвори профил <a>, или чрез страницата в нашата платформа.
            <p>Благодарим ти, че използваш нашия сайт!</p>
            <p>Поздрави, <br/> Екипът на 'Лапички+'</p>
        </body>
        </html>";
        
        var message = MailHelper.CreateSingleEmail(from, to, subject, null, htmlContent);

        var result = await client.SendEmailAsync(message, cancellationToken);

        return result.IsSuccessStatusCode;
    }

    public async Task<bool> SendPostDisapproveEmail(string sitterId, string stateReason, CancellationToken cancellationToken = default)
    {
        var userId = await profileQueryRepository.GetUserIdByProfileId(sitterId);
        var sitter = await userManager.FindByIdAsync(userId);
        
        var apiKey = Environment.GetEnvironmentVariable("SENDGRID_API_KEY");
        var myProfilePostPage = "https://localhost:4200/my-profile-details/notifications"; // fix link
        
        var client = new SendGridClient(apiKey);
        var from = new EmailAddress("no-reply@pawsplus.eu", "Лапички+");
        var subject = "Лапички+ - Имате нова заявка";
        var to = new EmailAddress(sitter.Email, sitter.UserName);
        var htmlContent = $@"
        <html>
        <body style='font-family: Oswald, sans-serif;'>
            <p>Привет, {sitter.UserName}!</p>
            <p>За съжаление, твоят профил <b>не е одобрен</b>.</p>
            <p>Причина/и за това е/са:</p>
            <p>{stateReason}</p>
            <p>Твоите усилия далеч не са били напразно, не се оберазкожавай. Помисли върху решаване на засегнатите поблеми и опитай отново. Очакваме те!</p>
            <p>Поздрави, <br/> Екипът на 'Лапички+'</p>
        </body>
        </html>";
        
        var message = MailHelper.CreateSingleEmail(from, to, subject, null, htmlContent);

        var result = await client.SendEmailAsync(message, cancellationToken);

        return result.IsSuccessStatusCode;
    }

    public async Task<bool> SendBookingApproveEmail(string ownerId, CancellationToken cancellationToken = default)
    {
        return true;
    }

    public async Task<bool> SendBookingDisapproveEmail(string ownerId, CancellationToken cancellationToken = default)
    {
        return true;
    }

    public async Task<bool> SendBookingCancelEmail(string sitterId, CancellationToken cancellationToken = default)
    {
        return true;
    }
}