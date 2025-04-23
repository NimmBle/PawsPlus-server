using PawsPlus.Domain.Common;
using PawsPlus.Domain.Models;

namespace PawsPlus.Domain.Factories.Booking;

public interface IBookingFactory : IFactory<Models.Booking>
{
    IBookingFactory WithStartDay(DateOnly startDay);
    
    IBookingFactory WithStartTime(TimeOnly startTime);
    
    IBookingFactory WithEndDay(DateOnly endDay);
    
    IBookingFactory WithEndTime(TimeOnly endTime);
    
    IBookingFactory WithMeetingPlace(MeetingPlace meetingPlace);
    
    IBookingFactory WithGooglePlaceId(string? meetingPlaceId);
    
    IBookingFactory WithAdditionalDescription(string? additionalDescription);
    
    IBookingFactory WithServiceId(string serviceId);
    
    IBookingFactory WithSitterId(string sitterId);
    
    IBookingFactory WithOwnerId(string ownerId);
}