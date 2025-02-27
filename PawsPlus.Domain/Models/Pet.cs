using Newtonsoft.Json;
using PawsPlus.Domain.Common;
using PawsPlus.Domain.Common.Models;
using PawsPlus.Domain.Enums.Pet;
using PawsPlus.Domain.Exceptions;
using PawsPlus.Domain.ValueObjects;
using static PawsPlus.Domain.Models.ModelConstants.Common;

namespace PawsPlus.Domain.Models;

public class Pet : Entity<string>, IAggregateRoot
{
    private Pet()
    {
    }
    
    internal Pet(
        string name,
        string photoUrl,
        Animal animal,
        Age age,
        Gender gender,
        ICollection<Breed> breeds,
        Weight? weight,
        Personality? personality,
        HealthStatus? healthStatus,
        string profileId
    )
        : this(name, photoUrl, animal, gender, weight, profileId)
    {
        this.Age = Age.Create(age);
        this.Breeds = breeds;
        this.Personality = Personality.Create(personality);
        this.HealthStatus = HealthStatus.Create(healthStatus);
    }

    internal Pet(
        string name,
        string photoUrl,
        Animal animal,
        Gender gender,
        Weight? weight,
        string profileId
    )
    {
        this.Validate(name, photoUrl);
        
        this.Id = Guid.NewGuid().ToString();
        this.Name = name;
        this.PhotoUrl = photoUrl;
        this.Animal = animal;
        this.Gender = gender;
        this.Weight = weight;
        this.ProfileId = profileId;
    }

    public string Name { get; private set; } = default!;

    public string PhotoUrl { get; private set; } = default!;
    
    public Animal Animal { get; private set; }
    
    public Age? Age { get; private set; }
    
    [JsonProperty(Required = Required.Always)]
    public Gender Gender { get; private set; }
    
    public ICollection<Breed> Breeds { get; private set; } = new HashSet<Breed>();
    
    public int? WeightId { get; private set; }
    
    public Weight? Weight { get; private set; }

    public Personality? Personality { get; private set; }

    public HealthStatus? HealthStatus { get; private set; }

    public string ProfileId { get; private set; }
    
    public Profile Profile { get; private set; } = null!;

    public void Update(
        string name,
        string photoUrl,
        Animal animal,
        Age age,
        Gender gender,
        ICollection<Breed> breeds,
        Weight? weight,
        Personality? personality,
        HealthStatus? healthStatus)
    {
        var newAge = Age.Create(age);
        var newPersonality = Personality.Create(personality);
        var newHealthStatus = HealthStatus.Create(healthStatus);
        
        this.Name = name;
        this.PhotoUrl = photoUrl;
        this.Animal = animal;
        this.Age = newAge;
        this.Gender = gender;
        this.Breeds = breeds;
        this.Weight = weight;
        this.Personality = newPersonality;
        this.HealthStatus = newHealthStatus;
        var i = 1;
    }

    private void UpdateBreeds(ICollection<Breed> breeds)
    {
        this.Breeds.Clear();

        this.Breeds = breeds;

    }
    
    
    private void Validate(string name, string photoUrl)
    {
        this.ValidateName(name);
        this.ValidatePhotoUrl(photoUrl);
    }

    private void ValidateName(string name)
        => Guard.ForStringLength<InvalidPetException>(
            name,
            MinNameLength,
            MaxNameLength,
            nameof(Name));

    private void ValidatePhotoUrl(string photoUrl)
        => Guard.ForValidUrl<InvalidPetException>(
            photoUrl,
            nameof(PhotoUrl));
}