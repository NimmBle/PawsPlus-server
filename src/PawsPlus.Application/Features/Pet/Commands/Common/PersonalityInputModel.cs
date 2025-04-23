using PawsPlus.Application.Common.Mapping;
using PawsPlus.Domain.Enums.Pet;
using PawsPlus.Domain.ValueObjects;

namespace PawsPlus.Application.Features.Pet.Commands.Common;

public class PersonalityInputModel : IMapFrom<Personality>
{
    public string? Temperament { get; set; }

    public string? ActivityLevel { get; set; }
    
    public Training? IsTrained { get; set; }
    
    public Fear? HasFears { get; set; }
    
    public string? FearsDescription { get; set; }

    public virtual void Mapping(AutoMapper.Profile profile)
        => profile.CreateMap<PersonalityInputModel, Personality>();
}