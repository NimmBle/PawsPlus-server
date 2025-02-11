using PawsPlus.Application.Common.Mapping;
using PawsPlus.Application.Features.Breed.Queries;
using PawsPlus.Domain.Enums.Pet;
using PawsPlus.Domain.ValueObjects;

namespace PawsPlus.Application.Features.Pet.Queries;

public class PetOutputModel : IMapFrom<Domain.Models.Pet>
{
    public string Id { get; set; }
    
    public string Name { get; set; } = default!;

    public string PhotoUrl { get; set; } = default!;

    public PetType PetType { get; set; }

    public Age? Age { get; set; }
    
    public Gender Gender { get; set; }

    public ICollection<BreedOutputModel> Breeds { get; set; }

    public string? Weight { get; set; }

    public Personality? Personality { get; set; }

    public HealthStatus? HealthStatus { get; set; }

    virtual public void Mapping(AutoMapper.Profile profile)
        => profile
            .CreateMap<Domain.Models.Pet, PetOutputModel>();
}