using Zoolandia.Domain.Common;

namespace Zoolandia.Domain.Models;

public class Pet : Entity<string>, IAggregateRoot
{
    
    public string ProfileId { get; set; }
    
    public Profile Profile { get; set; } = null!;
}