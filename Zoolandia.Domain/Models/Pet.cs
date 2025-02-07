using Newtonsoft.Json;
using Zoolandia.Domain.Common;
using Zoolandia.Domain.Enums.Pet;
using Zoolandia.Domain.ValueObjects;

namespace Zoolandia.Domain.Models;

public class Pet : Entity<string>, IAggregateRoot
{
    internal Pet(
        string name,
        string photoUrl,
        PetType petType,
        Age age,
        Gender gender,
        ICollection<Breed> breeds,
        string? weight,
        Personality? personality,
        HealthStatus? healthStatus,
        string profileId
    )
        : this(name, photoUrl, petType, gender, weight, profileId)
    {
        this.Age = Age.Create(age);
        this.Breeds = breeds;
        this.Personality = Personality.Create(personality);
        this.HealthStatus = HealthStatus.Create(healthStatus);
    }

    internal Pet(
        string name,
        string photoUrl,
        PetType petType,
        Gender gender,
        string? weight,
        string profileId
    )
    {
        this.Id = Guid.NewGuid().ToString();

        this.Name = name;
        this.PhotoUrl = photoUrl;
        this.PetType = petType;
        this.Gender = gender;
        this.Weight = weight;
        this.ProfileId = profileId;
    }

    public string Name { get; private set; } = default!;

    public string PhotoUrl { get; private set; } = default!;

    [JsonProperty(Required = Required.Always)]
    public PetType PetType { get; private set; }
    
    public Age? Age { get; private set; }
    
    [JsonProperty(Required = Required.Always)]
    public Gender Gender { get; private set; }
    
    public ICollection<Breed> Breeds { get; private set; } = new HashSet<Breed>();
    
    public string? Weight { get; private set; } // change type to Enum

    public Personality? Personality { get; private set; }

    public HealthStatus? HealthStatus { get; private set; }

    public string ProfileId { get; private set; }
    
    public Profile Profile { get; private set; } = null!;

    public void Update(
        string name,
        string photoUrl,
        PetType petType,
        Age age,
        Gender gender,
        ICollection<Breed> breeds,
        string? weight,
        Personality? personality,
        HealthStatus? healthStatus)
    {
        this.Name = name;
        this.PhotoUrl = photoUrl;
        this.PetType = petType;
        this.Age = Age.Create(age);
        this.Gender = gender;
        UpdateBreeds(breeds);
        this.Weight = weight;
        this.Personality = Personality.Create(personality);
        this.HealthStatus = HealthStatus.Create(healthStatus);
    }

    private void UpdateBreeds(ICollection<Breed> breeds)
    {
        this.Breeds.Clear();

        this.Breeds = breeds;

    }
}