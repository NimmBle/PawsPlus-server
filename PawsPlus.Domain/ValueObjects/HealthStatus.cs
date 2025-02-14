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
        => new (isVaccinated, isCastrated, takesMedications, hasEatingSchedule, otherDietaryNeeds, healthProblems);
    
    public static HealthStatus Create(HealthStatus healthStatus)
        => Create(
            healthStatus.IsVaccinated,
            healthStatus.IsCastrated,
            healthStatus.TakesMedications,
            healthStatus.HasEatingSchedule,
            healthStatus.OtherDietaryNeeds,
            healthStatus.HealthProblems); 
}