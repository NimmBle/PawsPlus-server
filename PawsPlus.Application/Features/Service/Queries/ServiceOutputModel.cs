using PawsPlus.Application.Common.Mapping;
using PawsPlus.Domain.Enums;
using PawsPlus.Domain.Models;

namespace PawsPlus.Application.Features.Service.Queries;

public class ServiceOutputModel : IMapFrom<Domain.Models.Service>
{
    
    public string Id { get; set; }
    
    public string Name { get; set; }
    
    public int Price { get; set; }
    
    public HashSet<DateOnly> AvailableDates { get; set; }
    
    public List<int> MeetingPlaces { get; set; }

    public virtual void Mapping(AutoMapper.Profile profile)
        => profile
            .CreateMap<Domain.Models.Service, ServiceOutputModel>()
            .ForMember(dest => dest.MeetingPlaces, opt => opt.MapFrom(src => src.MeetingPlaces.Select(meetingPlace => meetingPlace.Id)))
            .ForMember(dest => dest.AvailableDates, opt => opt.MapFrom(src => src.AvailableDates.Select(ad => ad.Day)));
}