using Zoolandia.Domain.Common;
using Zoolandia.Domain.Enums.Pet;

namespace Zoolandia.Domain.Models;

public class Breed : Entity<int>, IAggregateRoot 
{
    protected Breed(int id)
    {
        this.Id = id;
    }
    private Breed(int id, string name, PetType petType)
    {
        this.Id = id;
        this.Name = name;
        this.PetType = petType;
    }
    public string Name { get; private set; }
    
    public PetType PetType { get; private set; }
    public ICollection<Pet> Pets { get; private set; }

    public static Breed CreateDogBreed(int id, string name)
        => new Breed(id, name, PetType.Dog);
    
    public static Breed CreateCatBreed(int id, string name)
        => new Breed(id, name, PetType.Cat);
}