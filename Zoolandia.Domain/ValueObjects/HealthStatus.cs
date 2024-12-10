namespace Zoolandia.Domain.ValueObjects;


public record HealthStatus
{
    
    public bool IsVaccinated { get; private set; }
    
    public bool IsCastrated { get; private set; }
    
    public bool TakesMedications { get; private set; }
    
    public bool HasEatingSchedule { get; private set; }
    
    public string OtherDiateryNeeds { get; private set; }
    
    public string HealthProblems { get; private set; }
    
    public HealthStatus()
    {}
    
    private HealthStatus(
        bool isVaccinated,
        bool isCastrated,
        bool takesMedications,
        bool hasEatingSchedule,
        string otherDiateryNeeds,
        string healthProblems)
    {
        this.IsVaccinated = isVaccinated;
        this.IsCastrated = isCastrated;
        this.TakesMedications = takesMedications;
        this.HasEatingSchedule = hasEatingSchedule;
        this.OtherDiateryNeeds = otherDiateryNeeds;
        this.HealthProblems = healthProblems;
    }

    public static HealthStatus Create(
        bool isVaccinated,
        bool isCastrated,
        bool takesMedications,
        bool hasEatingSchedule,
        string otherDiateryNeeds,
        string healthProblems)
    {
        return new HealthStatus(isVaccinated, isCastrated, takesMedications, hasEatingSchedule, otherDiateryNeeds, healthProblems);
    }
}