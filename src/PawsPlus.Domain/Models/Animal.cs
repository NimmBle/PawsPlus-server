
using PawsPlus.Domain.Common;

namespace PawsPlus.Domain.Models;

public class Animal : Entity<int>, IAggregateRoot
{
    public Animal(int id, string name)
    {
        this.Id = id;
        this.Name = name;
    }
    
    public string Name { get; private set; }
    
    public List<Breed> Breeds { get; private set; } = new();
    
    public List<Post> Posts { get; private set; } = new(); 
}