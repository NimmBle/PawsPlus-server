using Microsoft.AspNetCore.Identity;
using PawsPlus.Application.Features.Profile;
using PawsPlus.Domain.Services;
using PawsPlus.Infrastructure.Data.Migrations;
using PawsPlus.Infrastructure.Identity;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace PawsPlus.Infrastructure.Services;

public class EmailSender(UserManager<User> userManager,
    IProfileQueryRepository profileQueryRepository)
    : IEmailSender
{
    
    private string apiKey =  Environment.GetEnvironmentVariable("SENDGRID_API_KEY");
    private const string orders = "http://localhost:4200/profile/my-profile-details/notifications";
    private const string post = "http://localhost:4200/profile/my-profile-details/my-post";
    
    private EmailAddress from = new ("no-reply@pawsplus.eu", "Eкипът на Лапички+");
    
    public async Task<bool> SendRequestEmail(string sitterId, string ownerId, CancellationToken cancellationToken = default)
    {
        var sitter = await profileQueryRepository.GetEmailInformation(sitterId);
        var owner = await profileQueryRepository.GetEmailInformation(ownerId);
        
        var profileNotificationsLink = "http://localhost:4200/my-profile-details/notifications";
        var client = new SendGridClient(apiKey);
        var subject = "Лапички+ - Имате нова заявка";
        var to = new EmailAddress(sitter.Email, sitter.FirstName);
        var htmlContent = $@"
        <html>
        <body style='font-family: Oswald, sans-serif;'>
          <p>Здравейте!</p>
          <p>Имате нова заявка от {owner.FirstName} {owner.LastName}</p>
          <p>
            За да видите повече детайли относно заявка, както и да я одобрите или откажете, вижте профила си в Лапички+ - <a href={orders}>Отвори профил</a>
          </p>
          <p>Поздрави, <br/> Екипът на 'Лапички+'</p>
        </body>
        </html>";
        
        var message = MailHelper.CreateSingleEmail(from, to, subject, null, htmlContent);

        var result = await client.SendEmailAsync(message);

        return result.IsSuccessStatusCode;
    }

    public async Task<bool> SendPostApproveEmail(string sitterId, CancellationToken cancellationToken = default)
    {
        var sitter = await profileQueryRepository.GetEmailInformation(sitterId);
        
        var client = new SendGridClient(apiKey);
        var subject = "Лапички+ - Статус на профил";
        var to = new EmailAddress(sitter.Email, sitter.FirstName);
        var htmlContent = $@"
        <html>
        <body style='font-family: Oswald, sans-serif;'>
            <p>Привет, {sitter.FirstName} {sitter.LastName}!</p>
            <p>Добри новини - твоят профил в Лапички+ е <b>одобрен</b>. Това го прави услугите, които предлагаш, достъпни за всички!</p>
            <p>Можеш да завършиш напълно своите услуги, чрез тази връзка - <a href={post}> Отвори профил <a>, или чрез страницата в нашата платформа.
            <p>Благодарим ти, че използваш нашия сайт!</p>
            <p>Поздрави, <br/> Екипът на 'Лапички+'</p>
        </body>
        </html>";
        
        var message = MailHelper.CreateSingleEmail(from, to, subject, null, htmlContent);

        var result = await client.SendEmailAsync(message, cancellationToken);

        return result.IsSuccessStatusCode;
    }

    public async Task<bool> SendPostDisapproveEmail(string sitterId,
        string stateReason,
        CancellationToken cancellationToken = default)
    {
        var sitter = await profileQueryRepository.GetEmailInformation(sitterId);
        
        var client = new SendGridClient(apiKey);
        var subject = "Лапички+ - Статус на профил";
        var to = new EmailAddress(sitter.Email, sitter.FirstName);
        var htmlContent = $@"
        <html>
        <body style='font-family: Oswald, sans-serif;'>
            <p>Привет, {sitter.FirstName} {sitter.LastName}!</p>
            <p>За съжаление, твоят профил <b>не е одобрен</b>.</p>
            <p>Причина/и за това е/са:</p>
            <p>{stateReason}</p>
            <p>Ако мислиш, че може да е станало недоразумение и наистина искаш да бъдеш пълноценна част от нашата платформа, не се колепай да пишеш на админа, с когото си имал интервю.</p>
            <p>Поздрави, <br/> Екипът на 'Лапички+'</p>
        </body>
        </html>";
        
        var message = MailHelper.CreateSingleEmail(from, to, subject, null, htmlContent);

        var result = await client.SendEmailAsync(message, cancellationToken);

        return result.IsSuccessStatusCode;
    }

    public async Task<bool> SendBookingApproveEmail(string serviceName,
        DateOnly startDay,
        TimeOnly startTime,
        string ownerId,
        CancellationToken cancellationToken = default)
    {
        var owner = await profileQueryRepository.GetEmailInformation(ownerId);
        
        var client = new SendGridClient(apiKey);
        var subject = "Лапички+ - Имате нова заявка";
        var to = new EmailAddress(owner.Email, owner.FirstName);
        var htmlContent = $@"
        <html>
        <body style='font-family: Oswald, sans-serif;'>
            <p>Здравей, {owner.FirstName} {owner.LastName}!</p>
            <p>Твоята заявка за <b>{serviceName} </b> на <b>{startDay} </b> от <b>{startTime} </b> е <b>одобрена</b>!</p>
            <p>За да прегледаш заявката си можеш да последваш връзката към нашата платформа: <a href={orders}>Отвори заявки</a>!</p>
            <p>Поздрави, <br/> Екипът на 'Лапички+'</p>
        </body>
        </html>";
        
        var message = MailHelper.CreateSingleEmail(from, to, subject, null, htmlContent);

        var result = await client.SendEmailAsync(message, cancellationToken);

        return result.IsSuccessStatusCode;
    }

    public async Task<bool> SendBookingDisapproveEmail(string serviceName,
        DateOnly startDay,
        TimeOnly startTime,
        string ownerId,
        CancellationToken cancellationToken = default)
    {
        var owner = await profileQueryRepository.GetEmailInformation(ownerId);
        
        var client = new SendGridClient(apiKey);
        var subject = "Лапички+ - Имате нова заявка";
        var to = new EmailAddress(owner.Email, owner.FirstName);
        var htmlContent = $@"
        <html>
        <body style='font-family: Oswald, sans-serif;'>
            <p>Здравей, {owner.FirstName} {owner.LastName}!</p>
            <p>Твоята заявка за <b>{serviceName} </b> на <b>{startDay} </b> от <b>{startTime} </b> е <b>неодобрена</b>!</p>
            <p>Поздрави, <br/> Екипът на 'Лапички+'</p>
        </body>
        </html>";
        
        var message = MailHelper.CreateSingleEmail(from, to, subject, null, htmlContent);

        var result = await client.SendEmailAsync(message, cancellationToken);

        return result.IsSuccessStatusCode;
    }

    public async Task<bool> SendBookingCancelEmail(string serviceName,
        DateOnly startDay,
        TimeOnly startTime,
        string sitterId,
        CancellationToken cancellationToken = default)
    {
        var sitter = await profileQueryRepository.GetEmailInformation(sitterId);
        
        var client = new SendGridClient(apiKey);
        var subject = "Лапички+ - Имате нова заявка";
        var to = new EmailAddress(sitter.Email, sitter.FirstName);
        var htmlContent = $@"
        <html>
        <body style='font-family: Oswald, sans-serif;'>
            <p>Здравей, {sitter.FirstName} {sitter.LastName}!</p>
            <p>Заявката за <b>{serviceName} </b> на <b>{startDay} </b> от <b>{startTime} </b> часа беше <b>отказана</b> от собственика!</p>
            <p>Поздрави, <br/> Екипът на 'Лапички+'</p>
        </body>
        </html>";
        
        var message = MailHelper.CreateSingleEmail(from, to, subject, null, htmlContent);

        var result = await client.SendEmailAsync(message, cancellationToken);

        return result.IsSuccessStatusCode;
    }
}