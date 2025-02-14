using PawsPlus.Domain.Common;
using PawsPlus.Domain.Common.Models;
using PawsPlus.Domain.Exceptions;
using PawsPlus.Domain.ValueObjects;
using static PawsPlus.Domain.Models.ModelConstants.Common;

namespace PawsPlus.Domain.Models;

public class Profile : Entity<string>, IAggregateRoot
{
    public Profile(string firstName, 
        string lastName,
        string phoneNumber)
    {
        this.Id = Guid.NewGuid().ToString();
        this.FirstName = firstName;
        this.LastName = lastName;
        this.PhoneNumber = phoneNumber;
    }

    public string FirstName { get; private set; }

    public string LastName { get; private set; }

    public string PhoneNumber { get; private set; }

    public string PhotoUrl { get; private set; } = "https://res.cloudinary.com/ds95qikmm/image/upload/v1736432338/vk3ewpd0s0xcaywgjd29.svg";

    public string? Description { get; private set; }

    public bool FirstLogin { get; private set; } = true;

    public Location? Location { get; set; }

    public Pet? Pet { get; private set; }
    
    public Post? Post { get; private set; }
    
    public virtual ICollection<Booking> BookingsAsSitter { get; set; } = new List<Booking>();
    
    public virtual ICollection<Booking> BookingsAsOwner { get; set; } = new List<Booking>();
    
    // public Meeting? Meeting { get; private set; }

    public Profile UpdateFirstName(string firstName)
    {
        ValidateFirstName(firstName);
        this.FirstName = firstName;

        return this;
    }

    public Profile UpdateLastName(string lastName)
    {
        ValidateLastName(lastName);
        this.LastName = lastName;

        return this;
    }

    public Profile UpdatePhotoUrl(string photoUrl)
    {
        ValidatePhotoUrl(photoUrl);
        this.PhotoUrl = photoUrl;

        return this;
    }
    
    public Profile UpdatePhoneNumber(string phoneNumber)
    {
        // ValidatePhoneNumber(phoneNumber);
        this.PhoneNumber = phoneNumber;

        return this;
    }

    public Profile UpdateDescription(string description)
    {
        // ValidateDescription(description);
        this.Description = description;

        return this;
    }

    public Profile UpdateLocation(string placeId,
        double latitude,
        double longitude)
    {
        this.Location = new Location(placeId,
            latitude,
            longitude);

        return this;
    }
    public void UpdateFirstLogin()
    {
        this.FirstLogin = false;
    }

    public void ValidateFirstName(string firstName)
        => Guard.ForStringLength<InvalidProfileException>(
            firstName,
            MinNameLength,
            MaxNameLength,
            nameof(FirstName));
    
    public void ValidateLastName(string lastName)
        => Guard.ForStringLength<InvalidProfileException>(
            lastName,
            MinNameLength,
            MaxNameLength,
            nameof(LastName));

    public void ValidatePhotoUrl(string photoUrl)
        => Guard.ForValidUrl<InvalidProfileException>(
            photoUrl,
            nameof(PhotoUrl));
}