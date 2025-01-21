using System.Collections;
using System.Collections.ObjectModel;
using Zoolandia.Domain.Common;
using Zoolandia.Domain.Common.Models;
using Zoolandia.Domain.Enums;
using Zoolandia.Domain.Enums.Pet;

namespace Zoolandia.Domain.Models;

public class Post : Entity<string>, IAggregateRoot
{
    private readonly HashSet<PetType> _types = new();
    private readonly HashSet<Weight>? _weights = new();
    private readonly HashSet<Service> _services = new();

    public Post()
    {
    }
    
    public Post(
        HashSet<PetType> types,
        HashSet<Weight> weights,
        string profileId)
    {
        this.Id = Guid.NewGuid().ToString();
        this._types = types;
        this._weights = weights;
        this.ProfileId = profileId;
    }

    public StateType Status { get; private set; } = StateType.None;
    
    public string ProfileId { get; private set; }
    public Profile Profile { get; set; }

    public ReadOnlyCollection<PetType> Types => _types.ToList().AsReadOnly();

    public ReadOnlyCollection<Weight>? Weights => _weights.ToList().AsReadOnly();
    
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