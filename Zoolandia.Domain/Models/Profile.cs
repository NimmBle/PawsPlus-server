using Zoolandia.Domain.Common;
using Zoolandia.Domain.Common.Models;
using Zoolandia.Domain.Exceptions;

using static Zoolandia.Domain.Models.ModelConstants.Common;
using static Zoolandia.Domain.Models.ModelConstants.Profile;

namespace Zoolandia.Domain.Models;

public class Profile : Entity<string>, IAggregateRoot
{
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string PhoneNumber { get; set; }

    public string PhotoUrl { get; set; } = "https://res.cloudinary.com/ds95qikmm/image/upload/v1732147641/happy-man-sitting-with-three-cats-armchair-cartoon 1.svg.svg";

    public string? Description { get; set; }

    public bool FirstLogin { get; set; } = true;

    // public string? Address { get; set; }

    public Pet? Pet { get; set; }
    
    public Post? Post { get; set; }

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

    public Profile UpdateDescription(string description)
    {
        // ValidateDescription(description);
        this.Description = description;

        return this;
    }
    
    public Profile UpdatePhoneNumber(string phoneNumber)
    {
        // ValidatePhoneNumber(phoneNumber);
        this.PhoneNumber = phoneNumber;

        return this;
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