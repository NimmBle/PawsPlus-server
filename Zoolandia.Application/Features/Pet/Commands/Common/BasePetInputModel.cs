using Zoolandia.Domain.Enums.Pet;

namespace Zoolandia.Application.Features.Pet.Commands.Common;

public abstract class BasePetInputModel<TCommand>
{
    public string Name { get; set; } = default!;

    public string PhotoUrl { get; set; } = default!;

    public PetType PetType { get; set; }

    public AgeInputModel? Age { get; set; }
    
    public Gender Gender { get; set; }

    public string Breed { get; set; }

    public string? Weight { get; set; }

    public PersonalityInputModel? Personality { get; set; }

    public HealthStatusInputModel? HealthStatus { get; set; }
    
}