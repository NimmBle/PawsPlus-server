using PawsPlus.Domain.Common;

namespace PawsPlus.Domain.Models;

public class Breed : Entity<string>, IAggregateRoot 
{
    protected Breed(string id)
    {
        this.Id = id;
    }
    private Breed(string id, string name, int animalTypeId)
    {
        this.Id = id;
        this.Name = name;
        this.AnimalTypeId = animalTypeId;
    }
    public string Name { get; private set; }
    
    public int AnimalTypeId { get; private set; }
    
    public AnimalType AnimalType { get; private set; }
    
    public ICollection<Pet> Pets { get; private set; }

    public static Breed CreateDogBreed(string id, string name)
        => new Breed(id, name, 1);
    
    public static Breed CreateCatBreed(string id, string name)
        => new Breed(id, name, 2);
}