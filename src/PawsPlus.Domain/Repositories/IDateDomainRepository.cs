using PawsPlus.Domain.Common;
using PawsPlus.Domain.Models;

namespace PawsPlus.Domain.Repositories;

public interface IDateDomainRepository : IDomainRepository<Date>
{
    Task<List<Date>> FindAll(DateOnly minDate, DateOnly maxDate, CancellationToken cancellationToken = default);
    
}