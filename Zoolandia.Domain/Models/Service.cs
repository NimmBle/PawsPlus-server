using Zoolandia.Domain.Common;

namespace Zoolandia.Domain.Models;

public class Service : Entity<string>, IAggregateRoot
{
    
    public string Name { get; set; }

    public int? Price { get; set; }

    public List<DateOnly> AvailableDates { get; set; } = new List<DateOnly>();
    
    public string PostId { get; set; }
    public Post Post { get; set; }
}