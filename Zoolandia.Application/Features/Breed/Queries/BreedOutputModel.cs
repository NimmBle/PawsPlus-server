using Zoolandia.Application.Common.Mapping;

namespace Zoolandia.Application.Features.Breed.Queries;

public class BreedOutputModel : IMapFrom<Domain.Models.Breed>
{
    public string Id { get; set; }
    
    public string Name { get; set; }

    public void Mapping(AutoMapper.Profile mapper)
        => mapper
            .CreateMap<Domain.Models.Breed, BreedOutputModel>();
}