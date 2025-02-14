using System.Text.Json.Serialization;
using PawsPlus.Domain.Enums;

namespace PawsPlus.Application.Features.Booking.Commands.Create;

public class CreateBookingInputModel
{
    public DateOnly FromDay { get; set; }
    
    public TimeOnly FromTime { get; set; }
    
    public DateOnly ToDay { get; set; }
    public TimeOnly ToTime { get; set; }
    
    public MeetingPlaceType MeetingPlaceType { get; set; }
    
    public string? MeetingPlaceLocation { get; set; }
    
    public string? AdditionalDescription { get; set; }
    
    public ServiceType ServiceType { get; set; }
    
    public string SitterId { get; set; }

}