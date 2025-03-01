using PawsPlus.Application.Common.Mapping;

namespace PawsPlus.Application.Features.Booking.Queries;

public class BookingOutputModel : IMapFrom<Domain.Models.Booking>
{
    public string Id { get; set; }
    
    public string FirstName { get; set; }
    
    public string LastName { get; set; }
    
    public string PhotoUrl { get; set; }
    
    public string OwnerDescription { get; set; }
    
    public DateOnly StartDay { get; init; }
    public TimeOnly StartTime { get; init; }
    
    public DateOnly EndDay { get; init; }
    public TimeOnly EndTime { get; init; }
    
    public int MeetingPlaceId { get; init; }
    
    public string? GooglePlaceId { get; init; }
    
    public string? AdditionalDescription { get; init; }
    
    public string SitterFirstName { get; init; }
    
    public string SitterLastName { get; init; }
    
    public string SitterPhotoUrl { get; init; }
    
    public string SitterId { get; init; }
    
    public string Status { get; init; }
    
    public string PetId { get; init; }
    public string PetType { get; init; }
    
    public string ServiceName { get; init; }

    public string OwnerId { get; init; }

    public void Mapping(AutoMapper.Profile mapper)
        => mapper
            .CreateMap<Domain.Models.Booking, BookingOutputModel>()
            .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.Owner.FirstName))
            .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.Owner.LastName))
            .ForMember(dest => dest.PhotoUrl, opt => opt.MapFrom(src => src.Owner.PhotoUrl))
            .ForMember(dest => dest.OwnerDescription, opt => opt.MapFrom(src => src.Owner.Description))
            .ForMember(dest => dest.SitterFirstName, opt => opt.MapFrom(src => src.Sitter.FirstName))
            .ForMember(dest => dest.SitterLastName, opt => opt.MapFrom(src => src.Sitter.LastName))
            .ForMember(dest => dest.SitterPhotoUrl, opt => opt.MapFrom(src => src.Sitter.PhotoUrl))
            .ForMember(dest => dest.SitterId, opt => opt.MapFrom(src => src.SitterId))
            .ForMember(dest => dest.Status, opt => opt.MapFrom(b => b.Status.Name))
            .ForMember(dest => dest.PetId, opt => opt.MapFrom(src => src.Owner.Pet.Id))
            .ForMember(dest => dest.PetType, opt => opt.MapFrom(src => src.Owner.Pet.Animal.Name))
            .ForMember(dest => dest.ServiceName, opt => opt.MapFrom(src => src.Service.Name));
}