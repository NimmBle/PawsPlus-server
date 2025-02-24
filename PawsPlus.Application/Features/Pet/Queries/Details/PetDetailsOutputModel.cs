using PawsPlus.Application.Common.Mapping;
using PawsPlus.Application.Features.Breed.Queries;
using PawsPlus.Application.Features.Profile.Queries.MinePet;
using PawsPlus.Domain.Enums.Pet;
using PawsPlus.Domain.Models;
using PawsPlus.Domain.ValueObjects;

namespace PawsPlus.Application.Features.Pet.Queries.Details;

public class PetDetailsOutputModel : IMapFrom<ModelConstants.Pet>
{
    public string Id { get; set; }
    
    public string Name { get; set; } = default!;

    public string PhotoUrl { get; set; } = default!;

    public int PetType { get; set; }

    public Age? Age { get; set; }
    
    public Gender Gender { get; set; }

    public ICollection<BreedOutputModel> Breeds { get; set; }

    public Weight? Weight { get; set; }

    public Personality? Personality { get; set; }

    public HealthStatus? HealthStatus { get; set; }

    virtual public void Mapping(AutoMapper.Profile profile)
        => profile
            .CreateMap<Domain.Models.Pet, PetDetailsOutputModel>()
            .ForMember(dest => dest.PetType, opt => opt.MapFrom(p => p.Animal.Id));

}