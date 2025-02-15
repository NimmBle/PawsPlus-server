using Microsoft.AspNetCore.Identity;
using PawsPlus.Domain.Repositories;
using PawsPlus.Domain.Services;
using PawsPlus.Infrastructure.Identity;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace PawsPlus.Infrastructure.Services;

public class EmailSender(UserManager<User> userManager,
    IProfileDomainRepository profileDomainRepository)
    : IEmailSender
{
    public async Task<bool> SendRequestEmail(string sitterId, string ownerId, CancellationToken cancellationToken = default)
    {
        var sitter = await userManager.FindByIdAsync(sitterId);
        var ownerProfile = await profileDomainRepository.FindByUser(ownerId);
        
        var apiKey = Environment.GetEnvironmentVariable("SENDGRID_API_KEY");
        var openProfileLink =
            $"https://www.youtube.com/watch?v=-NrFMmYVKbkz";
        
        
        var client = new SendGridClient(apiKey);
        var from = new EmailAddress("no-reply@pawsplus.eu", "Лапички+");
        var subject = "Лапички+ - Имате нова заявка";
        var to = new EmailAddress(sitter.Email, sitter.UserName);
        var htmlContent = $@"
        <html>
        <body style='font-family: Oswald, sans-serif;'>
          <p>Здравейте!</p>
          <p>Имате нова заявка от {ownerProfile.FirstName} {ownerProfile.LastName}</p>
          <p>
            За да видите повече детайли относно заявка, както и да я одобрите или откажете, вижте профила си в Лапички+ - <a href={openProfileLink}>Отвори профил</a>
          </p>
          <p>Поздрави, <br/> Екипът на 'Лапички+'</p>
        </body>
        </html>";
        
        var message = MailHelper.CreateSingleEmail(from, to, subject, null, htmlContent);

        var result = await client.SendEmailAsync(message);

        return result.IsSuccessStatusCode;
    }
}