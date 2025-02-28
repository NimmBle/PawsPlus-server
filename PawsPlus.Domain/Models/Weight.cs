using PawsPlus.Domain.Common;

namespace PawsPlus.Domain.Models;

public class Weight : Entity<int>, IAggregateRoot
{
    public Weight(int id, string name)
    {
        this.Id = id;
        this.Name = name;
    }
    
    public string Name { get; private set; }
    
    public List<Pet> Pets { get; private set; } = new();
    
    public List<Post> Posts { get; private set; } = new();
}