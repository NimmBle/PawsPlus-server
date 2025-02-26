using PawsPlus.Domain.Enums.Pet;
using PawsPlus.Domain.Models;
using PawsPlus.Domain.ValueObjects;
using Weight = PawsPlus.Domain.Models.Weight;

namespace PawsPlus.Domain.Factories.Pet;

public class PetFactory : IPetFactory
{
    private string name = default!;
    private string photoUrl = default!;
    private Animal animal = default!;
    private Age age = default!;
    private Gender gender;
    private ICollection<Breed> breeds;
    private Weight? weight = default;
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

    public IPetFactory WithType(Animal animal)
    {
        this.animal = animal;
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

    public IPetFactory WithBreed(ICollection<Breed> breeds)
    {
        this.breeds = breeds;
        return this;
    }

    public IPetFactory WithWeight(Weight? weight)
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

    public Models.Pet Build()
        => new (this.name,
            this.photoUrl,
            this.animal,
            this.age,
            this.gender,
            this.breeds,
            this.weight,
            this.personality,
            this.healthStatus,
            this.profileId);
}