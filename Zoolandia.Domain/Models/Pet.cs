using Zoolandia.Domain.Common;
using Zoolandia.Domain.Enums;
using Zoolandia.Domain.ValueObjects;

namespace Zoolandia.Domain.Models;

public class Pet : Entity<string>, IAggregateRoot
{

    public string Name { get; set; }

    public string PhotoUrl { get; set; }

    public Age Age { get; set; }
    
    public Gender Gender { get; set; }

    public Breed Breed { get; set; } // change type
    
    public string Weight { get; set; } // change type to Enum

    public Personality Personality { get; set; }
    
    public HealthStatus HealthStatus { get; set; }

    public string ProfileId { get; set; }
    
    public Profile Profile { get; set; } = null!;
}