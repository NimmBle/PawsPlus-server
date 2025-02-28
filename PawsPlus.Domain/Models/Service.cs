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
        List<MeetingPlace> meetingPlaces,
        string postId,
        List<Date> allAvailableDates)
        : this(serviceType)
    {
        this.Validate(price);
        this.Price = price;
        
        var validatedAvailableDates = this.ValidateAvailableDates(availableDates, allAvailableDates);
        this.AvailableDates = validatedAvailableDates;
        
        this.MeetingPlaces = meetingPlaces;
        this.PostId = postId;
    }

    public string Name { get; private set; }

    public int Price { get; private set; } = 0;

    public List<Date>? AvailableDates { get; private set; } = new();

    public List<Booking> Bookings { get; private set; } = new();

    public List<MeetingPlace> MeetingPlaces { get; private set; } = new();

    public string PostId { get; private set; }
    public Post Post { get; private set; }

    public void UpdatePrice(int newPrice)
    {
        this.ValidatePrice(newPrice);

        this.Price = newPrice;
    }

    public void UpdateAvailableDates(List<DateOnly>? newAvailableDates,
        List<Date> allAvailableDates)
    {
        var validatedAvailableDates = ValidateAvailableDates(newAvailableDates, allAvailableDates);

        this.AvailableDates = validatedAvailableDates;
    }

    public void UpdateMeetingPlaces(List<MeetingPlace> newMeetingPlaces)
    {
        this.MeetingPlaces = newMeetingPlaces;
    }

    private void Validate(int price)
    {
        this.ValidatePrice(price);
    }

    private void ValidatePrice(int price)
        => Guard.ForNegativeNumber<InvalidServiceException>(
            price,
            nameof(price));

    public List<Date> ValidateAvailableDates(List<DateOnly>? newAvailableDates,
        List<Date> allAvailableDates)
    {
        var availableDates = new List<Date>();
        for (int i = 0; i < newAvailableDates.Count; i++)
        {
            if (allAvailableDates.Any(d => d.Day == newAvailableDates[i]))
            {
                availableDates.Add(allAvailableDates.Where(d => d.Day == newAvailableDates[i]).SingleOrDefault());
            }
            else
            {
                availableDates.Add(new Date(newAvailableDates[i]));
            }
        }

        return availableDates;
    }
}