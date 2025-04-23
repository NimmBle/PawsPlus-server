using PawsPlus.Application.Common.Mapping;

namespace PawsPlus.Application.Features.Pet.Commands.Common;

public class BreedInputModel : IMapFrom<Domain.Models.Breed>
{
    public string Id { get; set; }
    
    public string Name { get; set; }

    public void Mapping(AutoMapper.Profile mapper)
        => mapper
            .CreateMap<BreedInputModel, Domain.Models.Breed>();
}   