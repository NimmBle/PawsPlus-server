namespace PawsPlus.Domain.Services;

public interface IEmailSender
{
    Task<bool> SendRequestEmail(string sitterId, CancellationToken cancellationToken = default);
    
    
    Task<bool> SendPostApproveEmail(string sitterId, CancellationToken cancellationToken = default);
    
    Task<bool> SendPostDisapproveEmail(string sitterId, string stateReason, CancellationToken cancellationToken = default);
    
    
    Task<bool> SendBookingApproveEmail(string ownerId, CancellationToken cancellationToken = default);
    
    Task<bool> SendBookingDisapproveEmail(string ownerId, CancellationToken cancellationToken = default);
    
    Task<bool> SendBookingCancelEmail(string sitterId, CancellationToken cancellationToken = default);
}