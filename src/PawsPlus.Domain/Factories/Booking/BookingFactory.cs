using PawsPlus.Domain.Models;

namespace PawsPlus.Domain.Factories.Booking;

public class BookingFactory : IBookingFactory
{
    private DateOnly startDay;
    private TimeOnly startTime;
    private DateOnly endDay;
    private TimeOnly endTime;
    private MeetingPlace meetingPlace;
    private string? googlePlaceId;
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

    public IBookingFactory WithMeetingPlace(MeetingPlace meetingPlace)
    {
        this.meetingPlace = meetingPlace;
        return this;
    }

    public IBookingFactory WithGooglePlaceId(string googlePlaceId)
    {
        this.googlePlaceId = googlePlaceId;
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
        => new(this.startDay,
            this.startTime,
            this.endDay,
            this.endTime,
            this.meetingPlace,
            this.googlePlaceId,
            this.additionalDescription,
            this.serviceId,
            this.sitterId,
            this.ownerId);
}