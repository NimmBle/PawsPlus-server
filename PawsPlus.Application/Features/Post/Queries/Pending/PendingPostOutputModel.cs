using AutoMapper;
using PawsPlus.Application.Common.Mapping;
using PawsPlus.Domain.Enums.Pet;

namespace PawsPlus.Application.Features.Post.Queries.Pending;

public class PendingPostOutputModel : IMapFrom<Domain.Models.Post>
{
    public string PostId { get; init; }
    
    public string FirstName { get; init; }
    
    public string LastName { get; init; }
    
    public string PhotoUrl { get; init; }
    
    public List<string> ServiceNames { get; init; }
    
    public List<string> AnimalTypes { get; init; }
    
    public string ProfileId { get; set; }

    public void Mapping(AutoMapper.Profile mapper)
        => mapper
            .CreateMap<Domain.Models.Post, PendingPostOutputModel>()
            .ForMember(p => p.FirstName, opt => opt.MapFrom(p => p.Profile.FirstName))
            .ForMember(p => p.LastName, opt => opt.MapFrom(p => p.Profile.LastName))
            .ForMember(p => p.PhotoUrl, opt => opt.MapFrom(p => p.Profile.PhotoUrl))
            .ForMember(p => p.ServiceNames, opt => opt.MapFrom(p => p.Services.Select( s => s.Name)))
            .ForMember(p => p.AnimalTypes, opt => opt.MapFrom(p => p.AnimalTypes.Select( s => s.Name)))
            .ForMember(p => p.PostId, opt => opt.MapFrom(p => p.Id))
            .ForMember(p => p.ProfileId, opt => opt.MapFrom(p => p.ProfileId));
}