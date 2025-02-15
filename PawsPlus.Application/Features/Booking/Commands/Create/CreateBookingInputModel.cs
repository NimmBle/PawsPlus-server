using System.Text.Json.Serialization;
using PawsPlus.Domain.Enums;

namespace PawsPlus.Application.Features.Booking.Commands.Create;

public class CreateBookingInputModel
{
    public DateOnly StartDay { get; set; }
    
    public TimeOnly StartTime { get; set; }
    
    public DateOnly EndDay { get; set; }
    
    public TimeOnly EndTime { get; set; }
    
    public MeetingPlaceType MeetingPlaceType { get; set; }
    
    public string? MeetingPlaceLocation { get; set; }
    
    public string? AdditionalDescription { get; set; }
    
    public ServiceType ServiceType { get; set; }
    
    public string SitterId { get; set; }

}