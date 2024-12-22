using Zoolandia.Application.Common;
using Zoolandia.Domain.Enums;
using Zoolandia.Domain.Models;
using Zoolandia.Domain.ValueObjects;

namespace Zoolandia.Application.Features.Pet.Commands.Common;

public abstract class PetCommand<TCommand>
{
    public string Name { get; set; } = default!;

    public string PhotoUrl { get; set; } = default!;

    public PetType PetType { get; set; } = default!;

    public int Years { get; set; }
    
    public int Months { get; set; }
    
    public Gender Gender { get; set; }

    public Breed Breed { get; set; }

    public string? Weight { get; set; } = default;

    public string? Temperament { get; set; } = default;
    
    public string? ActivityLevel { get; set; } = default;
    
    public Training? IsTrained { get; set; } = default;
    
    public Fear? HasFears { get; set; } = default;
    
    public string? FearsDescription { get; set; } = default;

    public bool? IsVaccinated { get; set; } = default;
    
    public bool? IsCastrated { get; set; } = default;
    
    public bool? TakesMedications { get; set; } = default;
    
    public bool? HasEatingSchedule { get; set; } = default;

    public string? OtherDietaryNeeds { get; set; } = default;
    
    public string? HealthProblems { get; set; } = default;

    public string ProfileId { get; set; } = default!;
}