using Newtonsoft.Json;
using Zoolandia.Domain.Common;
using Zoolandia.Domain.Enums.Pet;
using Zoolandia.Domain.ValueObjects;

namespace Zoolandia.Domain.Models;

public class Pet : Entity<string>, IAggregateRoot
{
    public Pet(
        string name,
        string photoUrl,
        PetType petType,
        Age age,
        Gender gender,
        Breed breed,
        string? weight,
        Personality? personality,
        HealthStatus? healthStatus,
        string profileId
    )
        : this(name, photoUrl, petType, gender, breed, weight, profileId)
    {
        this.Age = age;
        this.Personality = personality;
        this.HealthStatus = healthStatus;
    }

    private Pet(
        string name,
        string photoUrl,
        PetType petType,
        Gender gender,
        Breed breed,
        string? weight,
        string profileId
    )
    {
        this.Id = Guid.NewGuid().ToString();

        this.Name = name;
        this.PhotoUrl = photoUrl;
        this.PetType = petType;
        this.Gender = gender;
        this.Breed = breed;
        this.Weight = weight;
        this.ProfileId = profileId;
    }

    public string Name { get; set; } = default!;

    public string PhotoUrl { get; set; } = default!;

    [JsonProperty(Required = Required.Always)]
    public PetType PetType { get; set; }
    
    public Age? Age { get; set; }
    
    [JsonProperty(Required = Required.Always)]
    public Gender Gender { get; set; }

    [JsonProperty(Required = Required.Always)]
    public Breed Breed { get; set; }
    
    public string? Weight { get; set; } // change type to Enum

    public Personality? Personality { get; set; }

    public HealthStatus? HealthStatus { get; set; }

    public string ProfileId { get; set; }
    
    public Profile Profile { get; set; } = null!;
}