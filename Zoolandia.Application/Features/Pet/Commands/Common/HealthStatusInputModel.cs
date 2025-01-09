namespace Zoolandia.Application.Features.Pet.Commands.Common;

public class HealthStatusInputModel
{
    public bool? IsVaccinated { get; set; }
    
    public bool? IsCastrated { get; set; }
    
    public bool? TakesMedications { get; set; }
    
    public bool? HasEatingSchedule { get; set; }
    
    public string? OtherDietaryNeeds { get; set; }
    
    public string? HealthProblems { get; set; }
}