using PawsPlus.Domain.Models;
using PawsPlus.Domain.Repositories;
using PawsPlus.Infrastructure.Common.Persistence;

namespace PawsPlus.Infrastructure.Repositories;

public class BookingRepository(
    ZoolandiaDbContext db)
    : DataRepository<ZoolandiaDbContext, Booking>(db),
        IBookingDomainRepository
{
}