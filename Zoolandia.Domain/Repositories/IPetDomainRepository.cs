using Zoolandia.Domain.Common;
using Zoolandia.Domain.Models;

namespace Zoolandia.Domain.Repositories;

public interface IPetDomainRepository : IDomainRepository<Pet>
{
    
    Task<Pet> Find(string Id, CancellationToken cancellationToken = default);
    
    Task<bool> Delete(string Id, CancellationToken cancellationToken = default);
}