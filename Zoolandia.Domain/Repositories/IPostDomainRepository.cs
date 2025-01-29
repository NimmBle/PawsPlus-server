using Zoolandia.Domain.Common;
using Zoolandia.Domain.Models;

namespace Zoolandia.Domain.Repositories;

public interface IPostDomainRepository : IDomainRepository<Post>
{
    Task<Post> Find(string id, CancellationToken cancellationToken = default);
    
    Task<bool> Delete(string id, CancellationToken cancellationToken = default);
}