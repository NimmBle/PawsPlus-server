using Zoolandia.Application.Common;
using Zoolandia.Domain.Enums;
using Zoolandia.Domain.Models;
using Zoolandia.Domain.ValueObjects;

namespace Zoolandia.Application.Features.Pet.Commands.Common;

public abstract class PetCommand<TCommand> : EntityCommand<string>
{
    public string Name { get; set; }

    public string PhotoUrl { get; set; }

    public int Years { get; set; }
    
    public int Months { get; set; }
    
    public Gender Gender { get; set; }

    public Breed Breed { get; set; }

    public string? Weight { get; set; }

    public string? Temperament { get; private set; }
    
    public string? ActivityLevel { get; private set; }
    
    public Training? IsTrained { get; set; }
    
    public Fear? HasFears { get; set; }
    
    public string? FearsDescription { get; private set; }

    public bool? IsVaccinated { get; set; }
    
    public bool? IsCastrated { get; set; }
    
    public bool? TakesMedications { get; set; }
    
    public bool? HasEatingSchedule { get; set; }
    
    public string? OtherDiateryNeeds { get; set; }
    
    public string? HealthProblems { get; set; }

    public string ProfileId { get; set; }
}