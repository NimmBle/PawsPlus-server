using Zoolandia.Domain.Common;
using Zoolandia.Domain.Enums;
using Zoolandia.Domain.ValueObjects;

namespace Zoolandia.Domain.Models;

public class Pet : Entity<string>, IAggregateRoot
{
    public Pet(
        string name,
        string photoUrl,
        Age age,
        Gender gender,
        Breed breed,
        string? weight,
        Personality? personality,
        HealthStatus? healthStatus,
        string profileId
    )
        : this(name, photoUrl, gender, breed, weight, profileId)
    {
        this.Age = age;
        this.Personality = personality;
        this.HealthStatus = healthStatus;
    }

    private Pet(
        string name,
        string photoUrl,
        Gender gender,
        Breed breed,
        string? weight,
        string profileId
    )
    {
        this.Id = Guid.NewGuid().ToString();
        
        this.Name = name;
        this.PhotoUrl = photoUrl;
        this.Gender = gender;
        this.Breed = breed;
        this.Weight = weight;
        this.ProfileId = profileId;
    }

    public string Name { get; set; } = default!;

    public string PhotoUrl { get; set; } = default!;

    public Age? Age { get; set; }
    
    public Gender Gender { get; set; }

    public Breed Breed { get; set; }
    
    public string? Weight { get; set; } // change type to Enum

    public Personality? Personality { get; set; }

    public HealthStatus? HealthStatus { get; set; }

    public string ProfileId { get; set; }
    
    public Profile Profile { get; set; } = null!;
}