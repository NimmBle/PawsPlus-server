using PawsPlus.Application.Common.Mapping;
using PawsPlus.Domain.Enums;

namespace PawsPlus.Application.Features.Booking.Queries;

public class BookingOutputModel : IMapFrom<Domain.Models.Booking>
{
    public string Id { get; set; }
    
    public DateOnly StartDay { get; init; }
    public TimeOnly StartTime { get; init; }
    
    public DateOnly EndDay { get; init; }
    public TimeOnly EndTime { get; init; }
    
    public MeetingPlaceType MeetingPlaceType { get; init; }
    
    public string? MeetingPlaceId { get; init; }
    
    public string? AdditionalDescription { get; init; }
    
    public string ServiceId { get; init; }
    
    public string SitterId { get; init; }

    public string OwnerId { get; init; }
    
    public void Mapping(AutoMapper.Profile mapper)
        => mapper.CreateMap<Domain.Models.Booking, BookingOutputModel>();
}