using PawsPlus.Domain.Common.Models;
using PawsPlus.Domain.Exceptions;
using static PawsPlus.Domain.Models.ModelConstants.Common;
using static PawsPlus.Domain.Models.ModelConstants.Pet;

namespace PawsPlus.Domain.ValueObjects;


public record HealthStatus
{
    
    public bool? IsVaccinated { get; init; }
    
    public bool? IsCastrated { get; init; }
    
    public bool? TakesMedications { get; init; }
    
    public string? HasEatingSchedule { get; init; }
    
    public string? OtherDietaryNeeds { get; init; }
    
    public string? HealthProblems { get; init; }
    
    public HealthStatus()
    {}
    
    private HealthStatus(
        bool? isVaccinated,
        bool? isCastrated,
        bool? takesMedications,
        string? hasEatingSchedule,
        string? otherDietaryNeeds,
        string? healthProblems)
    {
        this.Validate(otherDietaryNeeds, healthProblems);
        
        this.IsVaccinated = isVaccinated;
        this.IsCastrated = isCastrated;
        this.TakesMedications = takesMedications;
        this.HasEatingSchedule = hasEatingSchedule;
        this.OtherDietaryNeeds = otherDietaryNeeds;
        this.HealthProblems = healthProblems;
    }

    public static HealthStatus Create(

        bool? isVaccinated,
        bool? isCastrated,
        bool? takesMedications,
        string? hasEatingSchedule,
        string? otherDietaryNeeds,
        string? healthProblems)
    {
        
       return new (isVaccinated, isCastrated, takesMedications, hasEatingSchedule, otherDietaryNeeds, healthProblems);
    }

    public static HealthStatus Create(HealthStatus healthStatus)
        => Create(
            healthStatus.IsVaccinated,
            healthStatus.IsCastrated,
            healthStatus.TakesMedications,
            healthStatus.HasEatingSchedule,
            healthStatus.OtherDietaryNeeds,
            healthStatus.HealthProblems);

    private void Validate(string? otherDietaryNeeds,
        string? healthProblems)
    {
        this.ValidateDietaryNeeds(otherDietaryNeeds);
        this.ValidateHealthProblems(healthProblems);
    }

    private void ValidateHealthProblems(string? healthProblems)
        => Guard.ForStringLength<InvalidPetException>(
            healthProblems,
            Zero,
            MaxDescriptionLength,
            nameof(HealthProblems));

    private void ValidateDietaryNeeds(string? dietaryNeeds)
        => Guard.ForStringLength<InvalidPetException>(
            dietaryNeeds,
            Zero,
            MaxDescriptionLength,
            nameof(OtherDietaryNeeds));
}