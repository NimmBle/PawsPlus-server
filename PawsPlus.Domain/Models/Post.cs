using PawsPlus.Domain.Common;
using PawsPlus.Domain.Common.Models;
using PawsPlus.Domain.Enums;
using PawsPlus.Domain.Enums.Pet;
using PawsPlus.Domain.Exceptions;

namespace PawsPlus.Domain.Models;

public class Post : Entity<string>, IAggregateRoot
{
    private readonly List<Service> _services = new();

    internal Post()
    {
    }

    public Post(List<Animal> animalTypes,
        List<Weight>? weights,
        string profileId)
    {
        this.Id = Guid.NewGuid().ToString();
        this.Animals = animalTypes.ToList();
        this.Weights = weights.ToList();
        this.ProfileId = profileId;
    }
    public PostState Status { get; private set; } = PostState.None;

    public string ProfileId { get; private set; }
    
    public Profile Profile { get; set; }

    public List<Animal> Animals { get; private set; } = new();

    public List<Weight>? Weights { get; private set; } = new();

    public IReadOnlyCollection<Service> Services => _services.AsReadOnly();

    public bool IsAlreadyResolved()
    {
        return Status.Equals(PostState.Approved) || 
               Status.Equals(PostState.Disapproved);
    }
    
    public void AddServices(List<ServiceType> services)
    {
        foreach (var service in services)
        {
            this._services.Add(new Service(service));
        }
    }

    public Post ChangeState(string type)
    {
        switch (type)
        {
            case "None":
                this.Status = Enumeration.FromValue<PostState>(1);
                break;
            case "Pending":
                this.Status = Enumeration.FromValue<PostState>(2);
                break;
            case "Disapproved":
                this.Status = Enumeration.FromValue<PostState>(3);
                break;
            case "Approved":
                this.Status = Enumeration.FromValue<PostState>(4);
                break;
        }

        return this;
    }
 
    public Post UpdatePetTypes(Animal animal)
    {
        if (this.Animals.Any(p => p == animal))
        {
            return this;
        }
        
        this.Animals.Add(animal);

        return this;
    }

    public Post UpdateWeights(List<Weight> weights)
    {
        this.Weights = weights;

        return this;
    }

    public void RemoveAnimalType(Animal animal)
    {
        if (this.Animals.Contains(animal))
        {
            this.Animals.Remove(animal);
        }

        if (animal.Name == "Dog")
        {
            this.Weights.Clear();
        }
    }
}