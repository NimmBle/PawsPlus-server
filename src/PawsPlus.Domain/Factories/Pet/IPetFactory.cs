using PawsPlus.Domain.Common;
using PawsPlus.Domain.Enums.Pet;
using PawsPlus.Domain.Models;
using Weight = PawsPlus.Domain.Models.Weight;

namespace PawsPlus.Domain.Factories.Pet;

public interface IPetFactory : IFactory<Models.Pet>
{
    IPetFactory WithName(string name);

    IPetFactory WithPhotoUrl(string photoUrl);

    IPetFactory WithType(Animal animal);

    IPetFactory WithAge(int years, int months);

    IPetFactory WithGender(Gender gender);

    IPetFactory WithBreed(ICollection<Breed> breeds);

    IPetFactory WithWeight(Weight? weight);

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