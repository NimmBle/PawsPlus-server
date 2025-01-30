using Zoolandia.Domain.Common;

namespace Zoolandia.Domain.Models;

public class Breed : Entity<string>, IAggregateRoot 
{
    public Breed(string name)
    {
        this.Id = Guid.NewGuid().ToString();
        this.Name = name;
    }
    public string Name { get; private set; }
    
    public ICollection<Pet> Pets { get; private set; }
}