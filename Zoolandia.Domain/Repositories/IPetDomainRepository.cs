using Zoolandia.Domain.Common;
using Zoolandia.Domain.Models;

namespace Zoolandia.Domain.Repositories;

public interface IPetDomainRepository : IDomainRepository<Pet>
{
    Task<Pet> Find(string petId, CancellationToken cancellationToken = default);
    Task<bool> Delete(string petId, CancellationToken cancellationToken = default);
}