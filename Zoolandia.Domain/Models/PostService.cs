using Zoolandia.Domain.Common;

namespace Zoolandia.Domain.Models;

public class PostService : Entity<string>
{
    public string PostId { get; set; }
    public string ServiceId { get; set; }
    
    public int Price { get; set; }
}