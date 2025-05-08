using PawsPlus.Domain.Common;
using PawsPlus.Domain.Common.Models;
using PawsPlus.Domain.Exceptions;
using static PawsPlus.Domain.Models.ModelConstants.Booking;
using static PawsPlus.Domain.Models.ModelConstants.Common;

namespace PawsPlus.Domain.Models;

public class Booking : Entity<string>, IAggregateRoot
{
    private Booking()
    {
    }
    
    internal Booking(DateOnly startDay,
        TimeOnly startTime,
        DateOnly endDay,
        TimeOnly endTime,
        MeetingPlace meetingPlace,
        string? googlePlaceId,
        string? additionalDescription,
        string serviceId,
        string sitterId,
        string ownerId)
    {
        this.Validate(additionalDescription);
        
        this.Id = Guid.NewGuid().ToString();
        this.StartDay = startDay;
        this.StartTime = startTime;
        this.EndDay = endDay;
        this.EndTime = endTime;
        this.MeetingPlace = meetingPlace;
        this.GooglePlaceId = googlePlaceId;
        this.AdditionalDescription = additionalDescription;
        this.Status = BookingState.Pending;
        this.ServiceId = serviceId;
        this.SitterId = sitterId;
        this.OwnerId = ownerId;
        
        this.CreatedAt = DateTime.UtcNow;
    }

    public DateOnly StartDay { get; private set; }
    public TimeOnly StartTime { get; private set; }
    
    public DateOnly EndDay { get; private set; }
    public TimeOnly EndTime { get; private set; }
    
    public int MeetingPlaceId { get; private set; }
    public MeetingPlace MeetingPlace { get; private set; }
    
    public string? GooglePlaceId { get; private set; }
    
    public string? AdditionalDescription { get; private set; }
    
    public BookingState Status { get; private set; } = BookingState.Pending;
    
    public string ServiceId { get; private set; }
    
    public virtual Service Service { get; set; }
    
    public string SitterId { get; private set; }
    
    public virtual Profile Sitter { get; set; }

    public string OwnerId { get; private set; }
    
    public virtual Profile Owner { get; set; }
    
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    
    public bool IsAlreadyResolved()
    {
        return Status.Equals(BookingState.Canceled) || 
               Status.Equals(BookingState.Disapproved) ||
               Status.Equals(BookingState.Approved);
    }

    public bool CannotStart()
    {
        return this.StartDay != DateOnly.FromDateTime(DateTime.Now) ||
               (this.StartDay == DateOnly.FromDateTime(DateTime.Now) &&
                this.StartTime > TimeOnly.FromDateTime(DateTime.Now));
    }
    public bool CannotComplete()
    {
        return this.EndDay != DateOnly.FromDateTime(DateTime.Now) ||
               (this.EndDay == DateOnly.FromDateTime(DateTime.Now) &&
                this.EndTime > TimeOnly.FromDateTime(DateTime.Now));
    }

    public Booking ChangeState(string type)
    {
        switch (type)
        {
            case "Pending":
                this.Status = Enumeration.FromValue<BookingState>(1);
                break;
            case "Canceled":
                this.Status = Enumeration.FromValue<BookingState>(2);
                break;
            case "Disapproved":
                this.Status = Enumeration.FromValue<BookingState>(3);
                break;
            case "Approved":
                this.Status = Enumeration.FromValue<BookingState>(4);
                break;
            case "Started":
                this.Status = Enumeration.FromValue<BookingState>(5);
                break;
            case "Completed":
                this.Status = Enumeration.FromValue<BookingState>(6);
                break;
        }

        return this;
    }

    private void Validate(string? additionalDescription)
    {
        this.ValidateDescription(additionalDescription);
    }

    private void ValidateDescription(string? additionalDescription)
        => Guard.ForStringLength<InvalidBookingException>(
            additionalDescription,
            Zero,
            MaxDescriptionLength,
            nameof(AdditionalDescription));
}