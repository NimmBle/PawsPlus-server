using PawsPlus.Domain.Enums;

namespace PawsPlus.Application.Features.Booking.Commands.Create;

public class CreateBookingInputModel
{
    public DateOnly StartDay { get; init; }
    
    public TimeOnly StartTime { get; init; }
    
    public DateOnly EndDay { get; init; }
    
    public TimeOnly EndTime { get; init; }
    
    public int MeetingPlaceType { get; init; }
    
    public string? MeetingPlaceId { get; init; }
    
    public string? AdditionalDescription { get; init; }
    
    public ServiceType ServiceType { get; init; }
    
    public string SitterId { get; init; }

}