using PawsPlus.Domain.Common;
using PawsPlus.Domain.Models;

namespace PawsPlus.Domain.Repositories;

public interface IAnimalTypeDomainRepository : IDomainRepository<Animal>
{
    Task<Animal> Find(int id, CancellationToken cancellationToken = default);
    
    Task<List<Animal>> FindAll(IEnumerable<int> ids, CancellationToken cancellationToken = default);
}