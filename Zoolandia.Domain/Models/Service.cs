using Zoolandia.Domain.Common;
using Zoolandia.Domain.Enums;

namespace Zoolandia.Domain.Models;

public class Service : Entity<string>, IAggregateRoot
{
    public string Name { get; set; }
    
    public List<Post> Posts { get; } = [];
}