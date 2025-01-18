using System.Collections;
using Zoolandia.Domain.Common;
using Zoolandia.Domain.Enums;
using Zoolandia.Domain.Enums.Pet;

namespace Zoolandia.Domain.Models;

public class Post : Entity<string>, IAggregateRoot
{
    
    public ICollection<PetType> Pets { get; set; } = new List<PetType>();
    
    public ICollection<Weight> Weights { get; set; } = new List<Weight>();
    
    public ICollection<Service> Services { get; } = new List<Service>();

    public PostStatus Status { get; set; } = PostStatus.Unscheduled;
    
    public string ProfileId { get; set; }
    public Profile Profile { get; set; }
}