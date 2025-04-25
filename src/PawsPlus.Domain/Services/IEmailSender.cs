namespace PawsPlus.Domain.Services;

public interface IEmailSender
{
    Task<bool> SendConfirmationEmail(string userId, string firstName = "", string lastName = "", CancellationToken cancellationToken = default);
    
    Task<bool> SendPostApproveEmail(string sitterId, CancellationToken cancellationToken = default);
    
    Task<bool> SendPostDisapproveEmail(string sitterId, string stateReason, CancellationToken cancellationToken = default);
    
    Task<bool> SendBookingRequestEmail(string sitterId, string ownerId, CancellationToken cancellationToken = default);
    
    Task<bool> SendBookingApproveEmail(string serviceName, DateOnly startDay, TimeOnly startTime, string ownerId, CancellationToken cancellationToken = default);
    
    Task<bool> SendBookingDisapproveEmail(string serviceName, DateOnly startDay, TimeOnly startTime, string ownerId, CancellationToken cancellationToken = default);
    
    // Task<bool> SendBookingStartEmail(string serviceName, DateOnly startDay, TimeOnly startTime, string ownerId, CancellationToken cancellationToken = default);
    
    Task<bool> SendBookingCancelEmail(string serviceName, DateOnly startDay, TimeOnly startTime, string sitterId, CancellationToken cancellationToken = default);
}