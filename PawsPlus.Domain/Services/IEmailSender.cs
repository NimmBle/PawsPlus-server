namespace PawsPlus.Domain.Services;

public interface IEmailSender
{
    Task<bool> SendRequestEmail(string sitterId, string ownerId, CancellationToken cancellationToken = default);
}