using PawsPlus.Application.Common.Mapping;
using PawsPlus.Domain.ValueObjects;

namespace PawsPlus.Application.Features.Pet.Commands.Common;

public class HealthStatusInputModel : IMapFrom<HealthStatus>
{
    public bool? IsVaccinated { get; set; }
    
    public bool? IsCastrated { get; set; }
    
    public bool? TakesMedications { get; set; }
    
    public string? HasEatingSchedule { get; set; }
    
    public string? OtherDietaryNeeds { get; set; }
    
    public string? HealthProblems { get; set; }
    
    public virtual void Mapping(AutoMapper.Profile profile)
        => profile.CreateMap<HealthStatusInputModel, HealthStatus>();
}