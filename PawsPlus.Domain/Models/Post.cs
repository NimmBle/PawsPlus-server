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
        List<PetType> petTypes,
        List<Weight> weights,
        string profileId)
    {
        this.Validate(petTypes, weights);
        
        this.Id = Guid.NewGuid().ToString();
        this.PetTypes = petTypes.ToList();
        this.Weights = weights.ToList();
        this.ProfileId = profileId;
    }
    public StateType Status { get; private set; } = StateType.None;

    public string ProfileId { get; private set; }
    
    public Profile Profile { get; set; }

    public List<PetType> PetTypes { get; private set; } = new();

    public List<Weight>? Weights { get; private set; } = new();

    public IReadOnlyCollection<Service> Services => _services.AsReadOnly();

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
                this.Status = Enumeration.FromValue<StateType>(1);
                break;
            case "Pending":
                this.Status = Enumeration.FromValue<StateType>(2);
                break;
            case "Disapproved":
                this.Status = Enumeration.FromValue<StateType>(3);
                break;
            case "Approved":
                this.Status = Enumeration.FromValue<StateType>(4);
                break;
        }

        return this;
    }
 
    public Post UpdatePetTypes(PetType petTypes)
    {
        if (this.PetTypes.Contains(petTypes))
            return this;
        
        this.PetTypes.Add(petTypes);

        return this;
    }

    public Post UpdateWeights(List<Weight> weights)
    {
        this.ValidateWeights(weights);
        
        this.Weights = weights;

        return this;
    }

    public void RemovePetType(PetType petType)
    {
        if (this.PetTypes.Contains(petType))
        {
            this.PetTypes.Remove(petType);
        }

        if (petType == PetType.Dog && this.PetTypes.Count > 0)
        {
            this.Weights.Clear();
        }
    }

    private void Validate(List<PetType> petTypes, List<Weight> weights)
    {
        this.ValidatePetTypes(petTypes);
        this.ValidateWeights(weights);
    }

    private void ValidatePetTypes(List<PetType> petTypes)
    {
        if (petTypes.All(w => Enum.IsDefined(typeof(PetType), w)))
        {
            return;
        }
        
        throw new InvalidPostException();
    }

    private void ValidateWeights(List<Weight> weights)
    {
        if (weights.All(w => Enum.IsDefined(typeof(Weight), w)))
        {
            return;
        }
        
        throw new InvalidPostException();
    } 
}