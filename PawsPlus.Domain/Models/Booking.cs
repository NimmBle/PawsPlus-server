using PawsPlus.Domain.Common;
using PawsPlus.Domain.Common.Models;
using PawsPlus.Domain.Enums;

namespace PawsPlus.Domain.Models;

public class Booking : Entity<string>, IAggregateRoot
{

    private Booking()
    {
    }
    
    public Booking(DateOnly startDay,
        TimeOnly startTime,
        DateOnly endDay,
        TimeOnly endTime,
        MeetingPlaceType meetingPlaceType,
        string? meetingPlaceLocation,
        string? additionalDescription,
        string serviceId,
        string sitterId,
        string ownerId)
    {
        this.Id = Guid.NewGuid().ToString();
        this.StartDay = startDay;
        this.StartTime = startTime;
        this.EndDay = endDay;
        this.EndTime = endTime;
        this.MeetingPlaceType = meetingPlaceType;
        this.MeetingPlaceLocation = meetingPlaceLocation;
        this.AdditionalDescription = additionalDescription;
        this.ServiceId = serviceId;
        this.SitterId = sitterId;
        this.OwnerId = ownerId;
    }

    public DateOnly StartDay { get; private set; }
    public TimeOnly StartTime { get; private set; }
    
    public DateOnly EndDay { get; private set; }
    public TimeOnly EndTime { get; private set; }
    
    public MeetingPlaceType MeetingPlaceType { get; private set; }
    
    public string? MeetingPlaceLocation { get; private set; }
    
    public string? AdditionalDescription { get; private set; }
    
    public RequestState RequestStatus { get; private set; } = RequestState.Pending;
    
    
    public string ServiceId { get; private set; }
    
    public virtual Service Service { get; set; }
    
    public string SitterId { get; private set; }
    
    public virtual Profile Sitter { get; set; }

    public string OwnerId { get; private set; }
    
    public virtual Profile Owner { get; set; }
    
    
    public Booking ChangeState(string type)
    {
        switch (type)
        {
            case "Pending":
                this.RequestStatus = Enumeration.FromValue<RequestState>(1);
                break;
            case "Canceled":
                this.RequestStatus = Enumeration.FromValue<RequestState>(2);
                break;
            case "Disapproved":
                this.RequestStatus = Enumeration.FromValue<RequestState>(3);
                break;
            case "Approved":
                this.RequestStatus = Enumeration.FromValue<RequestState>(4);
                break;
        }

        return this;
    }
}