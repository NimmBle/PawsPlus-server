namespace PawsPlus.Application.Features.Notification.Commands.RegisterDevice;

public class RegisterDeviceInputModel
{
    public string? ProfileId { get; set; }
    
    public string? BookingId { get; set; }
    
    public string DeviceToken { get; set; }
}