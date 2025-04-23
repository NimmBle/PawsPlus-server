using PawsPlus.Domain.Common;
using PawsPlus.Domain.Models;

namespace PawsPlus.Domain.Repositories;

public interface IPetDomainRepository : IDomainRepository<Pet>
{
    
    Task<Pet> Find(string Id, CancellationToken cancellationToken = default);
    
    Task<bool> Delete(string Id, CancellationToken cancellationToken = default);
}