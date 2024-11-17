using Zoolandia.Domain.Common;

namespace Zoolandia.Domain.Models;

public class Profile : Entity<string>, IAggregateRoot
{
    public string FirstName { get; set; }
    
    public string LastName { get; set; }
    
    public string PhoneNumber { get; set; }

    public string? PhotoUrl { get; set; } = "";
    
    public string? Description { get; set; }
    
    public Pet? Pet { get; set; }
    
    public JobPost? JobPost { get; set; }
}