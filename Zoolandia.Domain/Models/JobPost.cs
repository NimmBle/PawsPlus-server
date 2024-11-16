using Zoolandia.Domain.Common;

namespace Zoolandia.Domain.Models;

public class JobPost : Entity<string>, IAggregateRoot
{
    public string ProfileId { get; set; }
    
    public Profile Profile { get; set; } = null!;
}