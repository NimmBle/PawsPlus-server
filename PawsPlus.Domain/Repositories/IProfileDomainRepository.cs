using PawsPlus.Domain.Common;
using PawsPlus.Domain.Models;

namespace PawsPlus.Domain.Repositories;

public interface IProfileDomainRepository : IDomainRepository<Profile>
{
    Task<Profile> Find(string profileId, CancellationToken cancellationToken = default);
    
    Task<Profile> FindByUser(string userId, CancellationToken cancellationToken = default);
    
}