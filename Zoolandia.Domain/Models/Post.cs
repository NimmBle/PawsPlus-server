using System.Collections;
using System.Collections.ObjectModel;
using Zoolandia.Domain.Common;
using Zoolandia.Domain.Common.Models;
using Zoolandia.Domain.Enums;
using Zoolandia.Domain.Enums.Pet;

namespace Zoolandia.Domain.Models;

public class Post : Entity<string>, IAggregateRoot
{
    private readonly HashSet<Service> _services = new();

    internal Post()
    {
    }

    public Post(
        HashSet<PetType> petTypes,
        HashSet<Weight> weights,
        string profileId)
    {
        this.Id = Guid.NewGuid().ToString();
        this.PetTypes = petTypes.ToList();
        this.Weights = weights.ToList();
        this.ProfileId = profileId;
    }

    public StateType Status { get; private set; } = StateType.None;

    public string ProfileId { get; private set; }
    public Profile Profile { get; set; }

    public IList<PetType> PetTypes { get; set; } = new List<PetType>();

    public IList<Weight>? Weights { get; set; } = new List<Weight>();

    public IReadOnlyCollection<Service> Services => _services.ToList().AsReadOnly();

    public void AddServices(HashSet<ServiceType> services)
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
}