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

    public Post(
        List<AnimalType> animalTypes,
        List<Weight> weights,
        string profileId)
    {
        this.Validate(animalTypes, weights);
        
        this.Id = Guid.NewGuid().ToString();
        this.AnimalTypes = animalTypes.ToList();
        this.Weights = weights.ToList();
        this.ProfileId = profileId;
    }
    public PostState Status { get; private set; } = PostState.None;

    public string ProfileId { get; private set; }
    
    public Profile Profile { get; set; }

    public List<AnimalType> AnimalTypes { get; private set; } = new();

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
            this._services.Add(new Service(service));
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
 
    public Post UpdatePetTypes(AnimalType animalType)
    {
        if (this.AnimalTypes.Any(p => p == animalType))
        {
            return this;
        }
        
        this.AnimalTypes.Add(animalType);

        return this;
    }

    public Post UpdateWeights(List<Weight> weights)
    {
        this.ValidateWeights(weights);
        
        this.Weights = weights;

        return this;
    }

    public void RemovePetType(AnimalType animalType)
    {
        if (this.AnimalTypes.Contains(animalType))
        {
            this.AnimalTypes.Remove(animalType);
        }

        if (animalType.Name == "Dog")
        {
            this.Weights.Clear();
        }
    }

    private void Validate(List<AnimalType> petTypes, List<Weight> weights)
    {
        // this.ValidatePetTypes(petTypes);
        this.ValidateWeights(weights);
    }
    //
    // private void ValidatePetTypes(List<AnimalType> petTypes)
    // {
    //     if (petTypes.All(at => Enum.IsDefined(typeof(AnimalType), w)))
    //     {
    //         return;
    //     }
    //     
    //     throw new InvalidPostException();
    // }

    private void ValidateWeights(List<Weight> weights)
    {
        if (weights.All(w => Enum.IsDefined(typeof(Weight), w)))
        {
            return;
        }
        
        throw new InvalidPostException();
    } 
}