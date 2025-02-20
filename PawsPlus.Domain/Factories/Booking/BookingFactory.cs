using PawsPlus.Domain.Enums;

namespace PawsPlus.Domain.Factories.Booking;

public class BookingFactory : IBookingFactory
{
    private DateOnly startDay;
    private TimeOnly startTime;
    private DateOnly endDay;
    private TimeOnly endTime;
    private MeetingPlaceType meetingPlaceType;
    private string? meetingPlaceId;
    private string? additionalDescription;
    private string serviceId;
    private string sitterId;
    private string ownerId;
    
    public IBookingFactory WithStartDay(DateOnly startDay)
    {
        this.startDay = startDay;
        return this;
    }

    public IBookingFactory WithStartTime(TimeOnly startTime)
    {
        this.startTime = startTime;
        return this;
    }

    public IBookingFactory WithEndDay(DateOnly endDay)
    {
        this.endDay = endDay;
        return this;
    }

    public IBookingFactory WithEndTime(TimeOnly endTime)
    {
        this.endTime = endTime;
        return this;
    }

    public IBookingFactory WithMeetingPlaceType(MeetingPlaceType meetingPlaceType)
    {
        this.meetingPlaceType = meetingPlaceType;
        return this;
    }

    public IBookingFactory WithMeetingPlaceId(string meetingPlaceId)
    {
        this.meetingPlaceId = meetingPlaceId;
        return this;
    }

    public IBookingFactory WithAdditionalDescription(string additionalDescription)
    {
        this.additionalDescription = additionalDescription;
        return this;
    }

    public IBookingFactory WithServiceId(string serviceId)
    {
        this.serviceId = serviceId;
        return this;
    }

    public IBookingFactory WithSitterId(string sitterId)
    {
        this.sitterId = sitterId;
        return this;
    }

    public IBookingFactory WithOwnerId(string ownerId)
    {
        this.ownerId = ownerId;
        return this;
    }
    
    public Models.Booking Build()
        => new(startDay,
            startTime,
            endDay,
            endTime,
            meetingPlaceType,
            meetingPlaceId,
            additionalDescription,
            serviceId,
            sitterId,
            ownerId);
}