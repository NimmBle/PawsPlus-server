using PawsPlus.Domain.Enums.Pet;
using PawsPlus.Domain.Models;

namespace PawsPlus.Application.Features.Pet.Commands.Common;

public abstract class BasePetInputModel<TCommand>
{
    public string Name { get; set; } = default!;

    public string PhotoUrl { get; set; } = default!;

    public int PetType { get; set; }

    public AgeInputModel? Age { get; set; } = new AgeInputModel();
    
    public Gender Gender { get; set; }

    public ICollection<BreedInputModel> Breeds { get; set; }

    public Weight Weight { get; set; }

    public PersonalityInputModel? Personality { get; set; } = new PersonalityInputModel();

    public HealthStatusInputModel? HealthStatus { get; set; } = new HealthStatusInputModel();
    
}