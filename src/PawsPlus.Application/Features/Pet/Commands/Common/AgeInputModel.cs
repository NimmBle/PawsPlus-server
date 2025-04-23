using PawsPlus.Application.Common.Mapping;
using PawsPlus.Domain.ValueObjects;

namespace PawsPlus.Application.Features.Pet.Commands.Common;

public class AgeInputModel : IMapFrom<Age>
{
    public int Years { get; set; }
    
    public int Months { get; set; }

    public virtual void Mapping(AutoMapper.Profile profile)
        => profile.CreateMap<AgeInputModel, Age>();
}