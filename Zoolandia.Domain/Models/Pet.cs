using Zoolandia.Domain.Common;

namespace Zoolandia.Domain.Models;

public class Pet : Entity<string>, IAggregateRoot
{

    public string Name { get; set; }

    public string PhotoUrl { get; set; }

    public string Age { get; set; }
    
    public string Gender { get; set; }

    public string Breed { get; set; } // change type
    
    public string Weight { get; set; } // change type to Enum
    
    public string Personality { get; set; }

    public string ProfileId { get; set; }
    
    public Profile Profile { get; set; } = null!;
}