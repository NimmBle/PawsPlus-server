using Zoolandia.Domain.Common;

namespace Zoolandia.Domain.Models;

public class Profile : Entity<string>, IAggregateRoot
{
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string PhoneNumber { get; set; }

    public string? PhotoUrl { get; set; } = "";

    public string? Description { get; set; }

    public string? Address { get; set; }

    public Pet? Pet { get; set; }
    
    public JobPost? JobPost { get; set; }


    public Profile UpdateFirstName(string firstName)
    {
        // ValidateFirstName(firstName);
        this.FirstName = firstName;

        return this;
    }

    public Profile UpdateLastName(string lastName)
    {
        // ValidateLastName(lastName);
        this.LastName = lastName;

        return this;
    }

    public Profile UpdatePhotoUrl(string photoUrl)
    {
        // ValidatePhotoUrl(photoUrl);
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
}