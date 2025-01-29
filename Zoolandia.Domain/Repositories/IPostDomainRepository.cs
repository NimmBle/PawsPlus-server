using Zoolandia.Domain.Common;
using Zoolandia.Domain.Models;

namespace Zoolandia.Domain.Repositories;

public interface IPostDomainRepository : IDomainRepository<Post>
{
    Task<Post> GetWithoutServices(string id, CancellationToken cancellationToken = default);
    
    Task<Post> Get(string id, CancellationToken cancellationToken = default);
}