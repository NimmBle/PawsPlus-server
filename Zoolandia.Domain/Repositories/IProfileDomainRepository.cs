using Zoolandia.Domain.Common;
using Zoolandia.Domain.Models;

namespace Zoolandia.Domain.Repositories;

public interface IProfileDomainRepository : IDomainRepository<Profile>
{
    Task<Profile> Find(string profileId, CancellationToken cancellationToken = default);
    
    Task<Profile> FindByUser(string userId, CancellationToken cancellationToken = default);
    
}