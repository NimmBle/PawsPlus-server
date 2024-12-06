namespace Zoolandia.Domain.ValueObjects;


public record HealthStatus
{
    
    public bool IsVaccinated { get; private init; }
    
    public bool IsCastrated { get; private init; }
    
    public bool TakesMedications { get; private init; }
    
    public bool EatingSchedule { get; private init; }
    
    public string? OtherDiateryNeeds { get; private init; }
    
    public string? HealthProblems { get; private init; }
    
    public HealthStatus()
    {}
    
    private HealthStatus(
        bool isVaccinated,
        bool isCastrated,
        bool takesMedications,
        bool eatingSchedule,
        string? otherDiateryNeeds,
        string? healthProblems)
    {
        this.IsVaccinated = isVaccinated;
        this.IsCastrated = isCastrated;
        this.TakesMedications = takesMedications;
        this.EatingSchedule = eatingSchedule;
        this.OtherDiateryNeeds = otherDiateryNeeds;
        this.HealthProblems = healthProblems;
    }

    public static HealthStatus Create(
        bool isVaccinated,
        bool isCastrated,
        bool takesMedications,
        bool eatingSchedule,
        string? otherDiateryNeeds,
        string? healthProblems)
    {
        return new HealthStatus(isVaccinated, isCastrated, takesMedications, eatingSchedule, otherDiateryNeeds, healthProblems);
    }
}