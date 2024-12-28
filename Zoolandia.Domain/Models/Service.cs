using Zoolandia.Domain.Common;

namespace Zoolandia.Domain.Models;

public class Service : Entity<string>, IAggregateRoot
{
    
    public string Name { get; set; }
    
    public List<PostService> PostServices { get; } = [];
    public List<Post> Posts { get; } = [];
}