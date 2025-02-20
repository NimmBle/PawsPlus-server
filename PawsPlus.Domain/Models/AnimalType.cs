
using PawsPlus.Domain.Common;

namespace PawsPlus.Domain.Models;

public class AnimalType : Entity<int>, IAggregateRoot
{
    public AnimalType(int id)
    {
        Id = id;
    }
    
    public AnimalType(int id, string name)
    {
        this.Id = id;
        this.Name = name;
    }
    
    public string Name { get; private set; }
    
    public List<Breed> Breeds { get; private set; } = new List<Breed>();
    
    public List<Post> Posts { get; private set; } = new List<Post>(); 
}