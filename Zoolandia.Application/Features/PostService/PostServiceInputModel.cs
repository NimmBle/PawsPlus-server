using Zoolandia.Application.Common;

namespace Zoolandia.Application.Features.PostService;

public class PostServiceInputModel : EntityCommand<string>
{
    public int Price { get; set; }
        
    public List<DateOnly>? AvailableDates { get; set; }
}