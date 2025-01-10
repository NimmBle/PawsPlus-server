using Zoolandia.Domain.Common;
using Zoolandia.Domain.Models;

namespace Zoolandia.Domain.Repositories;

public interface IProfileDomainRepository : IDomainRepository<Profile>
{
    Task<Profile> Get(string profileId);
    
    Task<Profile> GetByUser(string userId);
    
    Task<string> GetProfileId(string userId, CancellationToken cancellationToken = default);
    
}