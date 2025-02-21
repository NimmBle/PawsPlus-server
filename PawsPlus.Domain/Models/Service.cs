using PawsPlus.Domain.Common;
using PawsPlus.Domain.Common.Models;
using PawsPlus.Domain.Enums;
using PawsPlus.Domain.Exceptions;

namespace PawsPlus.Domain.Models;

public class Service : Entity<string>, IAggregateRoot
{
    private Service()
    {
    }

    internal Service(ServiceType serviceType)
    {
        this.Id = Guid.NewGuid().ToString();
        this.Name = serviceType.ToString();
    }

    public Service(ServiceType serviceType,
        int price,
        List<DateOnly>? availableDates,
        List<MeetingPlaceType> meetingPlaces,
        string postId)
        : this(serviceType)
    {
        this.Validate(price, meetingPlaces);
            
        this.Price = price;
        this.AvailableDates = availableDates;
        this.MeetingPlaces = meetingPlaces;
        this.PostId = postId;
    }

    public string Name { get; private set; }

    public int Price { get; private set; } = 0;

    public List<DateOnly>? AvailableDates { get; private set; } = new List<DateOnly>();

    public ICollection<Booking> Bookings { get; private set; } = new List<Booking>();

    public List<MeetingPlaceType> MeetingPlaces { get; private set; } = new List<MeetingPlaceType>();

    public string PostId { get; private set; }
    public Post Post { get; private set; }

    public void UpdatePrice(int newPrice)
    {
        this.ValidatePrice(newPrice);

        this.Price = newPrice;
    }

    public void UpdateAvailableDates(List<DateOnly>? newAvailableDates)
    {
        var yesterday = DateOnly.FromDateTime(DateTime.Today.AddDays(-1));

        newAvailableDates.RemoveAll(date => date <= yesterday);

        this.AvailableDates = newAvailableDates;
    }

    public void UpdateMeetingPlaces(List<MeetingPlaceType> newMeetingPlaces)
    {
        this.ValidateMeetingPlaces(newMeetingPlaces);
        
        this.MeetingPlaces = newMeetingPlaces;
    }

    private void Validate(int price, List<MeetingPlaceType> meetingPlaces)
    {
        this.ValidatePrice(price);
        this.ValidateMeetingPlaces(meetingPlaces);
    }

    private void ValidatePrice(int price)
        => Guard.ForNegativeNumber<InvalidServiceException>(
            price,
            nameof(price));

    private void ValidateMeetingPlaces(List<MeetingPlaceType> meetingPlaces)
    {
        if (meetingPlaces.All(places => Enum.IsDefined(typeof(MeetingPlaceType), places)))
        {
            return;
        }

        throw new InvalidServiceException();
    } 
}