using PawsPlus.Domain.Common;
using PawsPlus.Domain.Models;

namespace PawsPlus.Domain.Repositories;

public interface IBreedDomainRepository : IDomainRepository<Breed>
{
    Task<Breed> Find(string id, CancellationToken cancellationToken = default);
    
    Task<List<Breed>> FindAll(IEnumerable<string> ids, CancellationToken cancellationToken = default);
}