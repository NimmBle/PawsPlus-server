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
            .ForMember(dest => dest.FirstName, opt => opt.MapFrom(p => p.Profile.FirstName))
            .ForMember(dest => dest.LastName, opt => opt.MapFrom(p => p.Profile.LastName))
            .ForMember(dest => dest.PhotoUrl, opt => opt.MapFrom(p => p.Profile.PhotoUrl))
            .ForMember(dest => dest.ServiceNames, opt => opt.MapFrom(p => p.Services.Select( s => s.Name)))
            .ForMember(dest => dest.AnimalTypes, opt => opt.MapFrom(p => p.Animals.Select( s => s.Name)))
            .ForMember(dest => dest.PostId, opt => opt.MapFrom(p => p.Id))
            .ForMember(dest => dest.ProfileId, opt => opt.MapFrom(p => p.ProfileId));
}