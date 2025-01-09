namespace Zoolandia.Domain.ValueObjects;


public record HealthStatus
{
    
    public bool? IsVaccinated { get; private set; }
    
    public bool? IsCastrated { get; private set; }
    
    public bool? TakesMedications { get; private set; }
    
    public bool? HasEatingSchedule { get; private set; }
    
    public string? OtherDietaryNeeds { get; private set; }
    
    public string? HealthProblems { get; private set; }
    
    public HealthStatus()
    {}
    
    private HealthStatus(
        bool? isVaccinated,
        bool? isCastrated,
        bool? takesMedications,
        bool? hasEatingSchedule,
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
        bool? hasEatingSchedule,
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