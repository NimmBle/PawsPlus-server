
using PawsPlus.Domain.Enums;

namespace PawsPlus.Application.Features.Service.Commands;

public abstract class ServiceInputModel
{
    public int Price { get; set; }
        
    public List<DateOnly>? AvailableDates { get; set; }
    
    public HashSet<int> MeetingPlaces { get; set; }
}