using PawsPlus.Domain.Common;
using PawsPlus.Domain.Models;

namespace PawsPlus.Domain.Repositories;

public interface IWeightDomainRepository : IDomainRepository<Weight>
{
    Task<Weight> Find(int? id, CancellationToken cancellationToken = default);
    
    Task<ICollection<Weight>> FindAll(IEnumerable<int> ids, CancellationToken cancellationToken = default);
}