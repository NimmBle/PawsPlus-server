using Zoolandia.Application.Common.Mapping;
using Zoolandia.Domain.Models;

namespace Zoolandia.Application.Features.Service;

public class ServiceOutputModel : IMapFrom<Domain.Models.Service>
{
    
    public string Id { get; set; }
    
    public string Name { get; set; }
    
    public int Price { get; set; }
    
    public List<DateOnly> AvailableDates { get; set; }

    public virtual void Mapping(AutoMapper.Profile profile)
        => profile.CreateMap<Domain.Models.Service, ServiceOutputModel>();
    
}