using Zoolandia.Domain.Enums.Pet;
using Zoolandia.Domain.Models;
using Zoolandia.Domain.ValueObjects;

namespace Zoolandia.Domain.Factories;

public class PetFactory : IPetFactory
{
    private string name = default!;
    private string photoUrl = default!;
    private PetType petType = default!;
    private Age age = default!;
    private Gender gender;
    private string breed;
    private string? weight = default;
    private Personality? personality = default;
    private HealthStatus? healthStatus = default;
    private string profileId;

    public IPetFactory WithName(string name)
    {
        this.name = name;
        return this;
    }

    public IPetFactory WithPhotoUrl(string photoUrl)
    {
        this.photoUrl = photoUrl;
        return this;
    }

    public IPetFactory WithType(PetType type)
    {
        this.petType = type;
        return this;
    }

    public IPetFactory WithAge(int years, int months)
    {
        if (years <= 0 && months <= 0)
            throw new ArgumentOutOfRangeException("Age must be greater than 0");
            
        this.age = Age.Create(years, months);
        return this;
    }

    public IPetFactory WithGender(Gender gender)
    {
        this.gender = gender;
        return this;
    }

    public IPetFactory WithBreed(string breed)
    {
        this.breed = breed;
        return this;
    }

    public IPetFactory WithWeight(string weight)
    {
        this.weight = weight;
        return this;
    }

    public IPetFactory WithPersonality(
        string? temperament,
        string? activityLevel,
        Training? isTrained,
        Fear? hasFears,
        string? fearsDescription)
    {
        this.personality = Personality
            .Create(temperament,
            activityLevel,
            isTrained,
            hasFears,
            fearsDescription);
        
        return this;
    }

    public IPetFactory WithHealthStatus(
        bool? isVaccinated,
        bool? isCastrated,
        bool? takesMedications,
        string? hasEatingSchedule,
        string? otherDietaryNeeds,
        string? healthProblems)
    {
        this.healthStatus = HealthStatus.Create(
            isVaccinated,
            isCastrated,
            takesMedications,
            hasEatingSchedule,
            otherDietaryNeeds,
            healthProblems);

        return this;
    }

    public IPetFactory WithProfileId(string profileId)
    {
        this.profileId = profileId;
        return this;
    }

    public Pet Build()
        => new Pet(
            this.name,
            this.photoUrl,
            this.petType,
            this.age,
            this.gender,
            this.breed,
            this.weight,
            this.personality,
            this.healthStatus,
            this.profileId);
}