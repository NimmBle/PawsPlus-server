using Zoolandia.Domain.Common;
using Zoolandia.Domain.Models;

namespace Zoolandia.Domain.Repositories;

public interface IBreedDomainRepository : IDomainRepository<Breed>
{
    Task<Breed> Find(string id, CancellationToken cancellationToken = default);
}