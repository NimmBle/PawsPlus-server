using PawsPlus.Domain.Common;
using PawsPlus.Domain.Models;

namespace PawsPlus.Domain.Repositories;

public interface IBookingDomainRepository : IDomainRepository<Booking>
{
    // Task<Booking> Find(string id, CancellationToken cancellationToken = default);
}