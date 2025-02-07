using Zoolandia.Application.Common.Mapping;

namespace Zoolandia.Application.Features.Pet.Commands.Common;

public class BreedInputModel : IMapFrom<Domain.Models.Breed>
{
    public int Id { get; set; }

    public void Mapping(AutoMapper.Profile mapper)
        => mapper
            .CreateMap<BreedInputModel, Domain.Models.Breed>();
}   