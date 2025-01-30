using Zoolandia.Domain.Enums.Pet;
using Zoolandia.Domain.Models;

namespace Zoolandia.Application.Features.Pet.Commands.Common;

public abstract class BasePetInputModel<TCommand>
{
    public string Name { get; set; } = default!;

    public string PhotoUrl { get; set; } = default!;

    public PetType PetType { get; set; }

    public AgeInputModel? Age { get; set; } = new AgeInputModel();
    
    public Gender Gender { get; set; }

    public ICollection<Domain.Models.Breed> Breeds { get; set; }

    public string? Weight { get; set; }

    public PersonalityInputModel? Personality { get; set; } = new PersonalityInputModel();

    public HealthStatusInputModel? HealthStatus { get; set; } = new HealthStatusInputModel();
    
}