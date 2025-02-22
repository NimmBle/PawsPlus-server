using PawsPlus.Application.Common.Mapping;
using PawsPlus.Domain.Enums;

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
    
    public MeetingPlaceType MeetingPlaceType { get; init; }
    
    public string? MeetingPlaceId { get; init; }
    
    public string? AdditionalDescription { get; init; }
    
    public string Status { get; init; }
    
    public string PetId { get; init; }
    
    public string ServiceName { get; init; }

    public string OwnerId { get; init; }

    public void Mapping(AutoMapper.Profile mapper)
        => mapper
            .CreateMap<Domain.Models.Booking, BookingOutputModel>()
            .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.Owner.FirstName))
            .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.Owner.LastName))
            .ForMember(dest => dest.PhotoUrl, opt => opt.MapFrom(src => src.Owner.PhotoUrl))
            .ForMember(dest => dest.OwnerDescription, opt => opt.MapFrom(src => src.Owner.Description))
            .ForMember(dest => dest.Status, opt => opt.MapFrom(b => b.Status.Name))
            .ForMember(dest => dest.PetId, opt => opt.MapFrom(src => src.Owner.Pet.Id))
            .ForMember(dest => dest.ServiceName, opt => opt.MapFrom(src => src.Service.Name));
}