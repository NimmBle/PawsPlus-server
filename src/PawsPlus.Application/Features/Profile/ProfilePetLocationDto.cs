using PawsPlus.Application.Common.Mapping;

namespace PawsPlus.Application.Features.Profile;

public class ProfilePetLocationDto : IMapFrom<Domain.Models.Profile>
{
    public string OwnerId { get; set; }
    
    public bool HasPet { get; set; }
    
    public string PlaceId { get; set; }

    public void Mapping(AutoMapper.Profile mapper)
        => mapper
            .CreateMap<Domain.Models.Profile, ProfilePetLocationDto>()
            .ForMember(dest => dest.OwnerId, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.HasPet, opt => opt.MapFrom(src => src.Pet != null))
            .ForMember(dest => dest.PlaceId, opt => opt.MapFrom(src => src.Location.PlaceId));
}