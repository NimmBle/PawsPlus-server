using Zoolandia.Domain.Enums;
using Zoolandia.Domain.Models;
using Zoolandia.Domain.ValueObjects;

namespace Zoolandia.Domain.Factories;

public class PetFactory : IPetFactory
{
    private string name = default!;
    private string photoUrl = default!;
    private Age age = default!;
    private Gender gender;
    private Breed breed;
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

    public IPetFactory WithAge(int years, int months)
    {
        this.age = Age.Create(years, months);
        return this;
    }

    public IPetFactory WithGender(Gender gender)
    {
        this.gender = gender;
        return this;
    }

    public IPetFactory WithBreed(Breed breed)
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
        bool? hasEatingSchedule,
        string? otherDietaryNeeds,
        string? healthProblems)
    {
        this.healthStatus = HealthStatus
            .Create(isVaccinated,
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
            this.age,
            this.gender,
            this.breed,
            this.weight,
            this.personality,
            this.healthStatus,
            this.profileId);
}