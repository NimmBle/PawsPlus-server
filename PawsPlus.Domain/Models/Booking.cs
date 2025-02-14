using PawsPlus.Domain.Common;
using PawsPlus.Domain.Common.Models;
using PawsPlus.Domain.Enums;

namespace PawsPlus.Domain.Models;

public class Booking : Entity<string>, IAggregateRoot
{

    private Booking()
    {
    }
    
    public Booking(DateOnly fromDay,
        TimeOnly fromTime,
        DateOnly toDay,
        TimeOnly toTime,
        MeetingPlaceType meetingPlaceType,
        string? meetingPlaceLocation,
        string? additionalDescription,
        string serviceId,
        string sitterId,
        string ownerId)
    {
        this.Id = Guid.NewGuid().ToString();
        this.FromDay = fromDay;
        this.FromTime = fromTime;
        this.ToDay = toDay;
        this.ToTime = toTime;
        this.MeetingPlaceType = meetingPlaceType;
        this.MeetingPlaceLocation = meetingPlaceLocation;
        this.AdditionalDescription = additionalDescription;
        this.ServiceId = serviceId;
        this.SitterId = sitterId;
        this.OwnerId = ownerId;
    }

    public DateOnly FromDay { get; private set; }
    public TimeOnly FromTime { get; private set; }
    
    public DateOnly ToDay { get; private set; }
    public TimeOnly ToTime { get; private set; }
    
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