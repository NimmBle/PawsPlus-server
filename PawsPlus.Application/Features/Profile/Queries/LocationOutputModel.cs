using PawsPlus.Application.Common.Mapping;
using PawsPlus.Domain.ValueObjects;

namespace PawsPlus.Application.Features.Profile.Queries;

public class LocationOutputModel : IMapFrom<Location>
{
    public string PlaceId { get; set; }

    public void Mapping(AutoMapper.Profile mapper)
        => mapper
            .CreateMap<Location, LocationOutputModel>();
    
}