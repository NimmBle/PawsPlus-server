using PawsPlus.Domain.Common;
using PawsPlus.Domain.Models;

namespace PawsPlus.Domain.Repositories;

public interface IServiceDomainRepository : IDomainRepository<Service>
{
    Task<Service> Find(string id, CancellationToken cancellationToken = default);
    
    Task<bool> Delete(string id, CancellationToken cancellationToken = default);
    
    Task<bool> AlreadyExists(string serviceName, string postId, CancellationToken cancellationToken = default);
}