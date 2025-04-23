using PawsPlus.Domain.Common;
using PawsPlus.Domain.Models;

namespace PawsPlus.Domain.Repositories;

public interface IReviewDomainRepository : IDomainRepository<Review>
{
    Task<bool> Delete(string Id, CancellationToken cancellationToken = default);
}