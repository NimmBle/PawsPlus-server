using Zoolandia.Domain.Common;

namespace Zoolandia.Domain.Models;

public class PostService : Entity<string>, IAggregateRoot
{
    public string PostId { get; set; }
    public Post Post { get; set; }
    
    public string ServiceId { get; set; }
    public Service Service { get; set; }
    
    public int Price { get; set; }
    
    public List<DateOnly>? AvailableDates { get; set; }
}