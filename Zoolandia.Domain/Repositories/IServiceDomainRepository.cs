using Zoolandia.Domain.Common;
using Zoolandia.Domain.Models;

namespace Zoolandia.Domain.Repositories;

public interface IServiceDomainRepository : IDomainRepository<Service>
{
    Task<Service> Find(string id, CancellationToken cancellationToken = default);
    
    Task<bool> Delete(string id, CancellationToken cancellationToken = default);
    
    Task<bool> AlreadyExists(string serviceName, string postId, CancellationToken cancellationToken = default);
}