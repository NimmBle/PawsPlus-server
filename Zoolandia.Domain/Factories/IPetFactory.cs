using Zoolandia.Domain.Common;
using Zoolandia.Domain.Enums.Pet;
using Zoolandia.Domain.Models;

namespace Zoolandia.Domain.Factories;

public interface IPetFactory : IFactory<Pet>
{
    IPetFactory WithName(string name);

    IPetFactory WithPhotoUrl(string photoUrl);

    IPetFactory WithType(PetType type);

    IPetFactory WithAge(int years, int months);

    IPetFactory WithGender(Gender gender);

    IPetFactory WithBreed(ICollection<Breed> breeds);

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
        string? hasEatingSchedule,
        string? otherDietaryNeeds,
        string? healthProblems);

    IPetFactory WithProfileId(string profileId);
}