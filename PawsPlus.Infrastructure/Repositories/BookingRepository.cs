using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PawsPlus.Application.Features.Booking;
using PawsPlus.Application.Features.Booking.Queries;
using PawsPlus.Domain.Models;
using PawsPlus.Domain.Repositories;
using PawsPlus.Infrastructure.Common.Persistence;

namespace PawsPlus.Infrastructure.Repositories;

public class BookingRepository(
    ZoolandiaDbContext db,
    IMapper mapper)
    : DataRepository<ZoolandiaDbContext, Booking>(db),
        IBookingDomainRepository,
        IBookingQueryRepository
{
    public async Task<Booking> Find(string id, CancellationToken cancellationToken = default)
        => await this
            .All()
            .FirstOrDefaultAsync(b => b.Id == id, cancellationToken);

    public async Task<ICollection<BookingOutputModel>> GetPendingBookings(string sitterId,
        CancellationToken cancellationToken = default)
        => await mapper
            .ProjectTo<BookingOutputModel>(this
                .All()
                .Where(b => b.SitterId == sitterId && 
                            b.Status.Value == BookingState.Pending.Value))
            .ToListAsync(cancellationToken);
}