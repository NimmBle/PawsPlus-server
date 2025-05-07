using PawsPlus.Domain.Common;

namespace PawsPlus.Domain.Models;

public class DeviceToken : IAggregateRoot
{
    public DeviceToken(string profileId,
        string token)
    {
        Id = Guid.NewGuid().ToString();
        
        ProfileId = profileId;
        Token = token;
    }

    public string Id { get; private set; }

    public string ProfileId { get; private set; }
    
    public string Token { get; private set; } 
}