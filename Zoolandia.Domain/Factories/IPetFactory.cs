using Zoolandia.Domain.Common;
using Zoolandia.Domain.Enums;
using Zoolandia.Domain.Models;
using Zoolandia.Domain.ValueObjects;

namespace Zoolandia.Domain.Factories;

public interface IPetFactory : IFactory<Pet>
{
    IPetFactory WithName(string name);

    IPetFactory WithPhotoUrl(string photoUrl);

    IPetFactory WithType(PetType type);

    IPetFactory WithAge(int years, int months);

    IPetFactory WithGender(Gender gender);

    IPetFactory WithBreed(Breed breed);

    IPetFactory WithWeight(string weight);

    IPetFactory WithPersonality(
        string? temperament,
        string? activityLevel,
        Training? isTrained,
        Fear? hasFears,
        string? fearsDescription);

    IPetFactory WithHealthStatus(
        bool? isVaccinated,
        bool? isCastrated,
        bool? takesMedications,
        bool? hasEatingSchedule,
        string? otherDietaryNeeds,
        string? healthProblems);

    IPetFactory WithProfileId(string profileId);
}