using PawsPlus.Application.Common.Mapping;
using PawsPlus.Domain.Enums;

namespace PawsPlus.Application.Features.Service.Queries;

public class ServiceOutputModel : IMapFrom<Domain.Models.Service>
{
    
    public string Id { get; set; }
    
    public string Name { get; set; }
    
    public int Price { get; set; }
    
    public HashSet<DateOnly> AvailableDates { get; set; }
    
    public List<MeetingPlaceType> MeetingPlaces { get; set; }

    public virtual void Mapping(AutoMapper.Profile profile)
        => profile.CreateMap<Domain.Models.Service, ServiceOutputModel>();
    
}