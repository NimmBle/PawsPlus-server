using PawsPlus.Domain.Common;
using PawsPlus.Domain.Enums;

namespace PawsPlus.Domain.Factories.Booking;

public interface IBookingFactory : IFactory<Models.Booking>
{
    IBookingFactory WithStartDay(DateOnly startDay);
    
    IBookingFactory WithStartTime(TimeOnly startTime);
    
    IBookingFactory WithEndDay(DateOnly endDay);
    
    IBookingFactory WithEndTime(TimeOnly endTime);
    
    IBookingFactory WithMeetingPlaceType(MeetingPlaceType meetingPlaceType);
    
    IBookingFactory WithMeetingPlaceId(string? meetingPlaceId);
    
    IBookingFactory WithAdditionalDescription(string? additionalDescription);
    
    IBookingFactory WithServiceId(string serviceId);
    
    IBookingFactory WithSitterId(string sitterId);
    
    IBookingFactory WithOwnerId(string ownerId);
}