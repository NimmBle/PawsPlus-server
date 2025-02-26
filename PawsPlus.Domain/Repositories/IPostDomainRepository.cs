using PawsPlus.Domain.Common;
using PawsPlus.Domain.Models;

namespace PawsPlus.Domain.Repositories;

public interface IPostDomainRepository : IDomainRepository<Post>
{
    Task<Post> Find(string id, CancellationToken cancellationToken = default);
    
    Task<Post> FindByProfile(string profileId, CancellationToken cancellationToken = default);
    
    Task<bool> Delete(string id, CancellationToken cancellationToken = default);
}