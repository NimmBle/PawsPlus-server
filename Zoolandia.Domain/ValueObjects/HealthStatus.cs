namespace Zoolandia.Domain.ValueObjects;

public record HealthStatus
{
    
    private bool IsVaccinated { get; init; }
    
    private bool IsCastrated { get; init; }
    
    private bool TakesMedications { get; init; }
    
    private bool EatingSchedule { get; init; }
    
    private string? OtherDiateryNeeds { get; init; }
    
    private string? HealthProblems { get; init;  }
    
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