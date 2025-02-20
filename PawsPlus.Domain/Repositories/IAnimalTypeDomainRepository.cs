using PawsPlus.Domain.Common;
using PawsPlus.Domain.Models;

namespace PawsPlus.Domain.Repositories;

public interface IAnimalTypeDomainRepository : IDomainRepository<AnimalType>
{
    Task<AnimalType> Find(int id, CancellationToken cancellationToken = default);
    
    Task<List<AnimalType>> FindAll(IEnumerable<int> ids, CancellationToken cancellationToken = default);
}