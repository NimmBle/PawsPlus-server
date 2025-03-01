using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PawsPlus.Application.Features.Booking;
using PawsPlus.Application.Features.Booking.Queries;
using PawsPlus.Domain.Models;
using PawsPlus.Domain.Repositories;
using PawsPlus.Infrastructure.Common.Persistence;

namespace PawsPlus.Infrastructure.Repositories;

public class BookingRepository(PawsPlusDbContext db,
    IMapper mapper)
    : DataRepository<PawsPlusDbContext, Booking>(db),
        IBookingDomainRepository,
        IBookingQueryRepository
{
    public async Task<Booking> Find(string id,
        CancellationToken cancellationToken = default)
        => await this
            .All()
            .FirstOrDefaultAsync(b => b.Id == id, cancellationToken);

    public async Task<Booking> FindByServiceId(string serviceId,
        CancellationToken cancellationToken = default)
        => await this
            .All()
            .FirstOrDefaultAsync(b => b.ServiceId == serviceId, cancellationToken);

    public async Task<ICollection<BookingOutputModel>> GetPendingBookings(string id,
        CancellationToken cancellationToken = default)
        => await mapper
            .ProjectTo<BookingOutputModel>(this
                .All()
                .Where(b => b.SitterId == id || b.OwnerId == id)
                .AsNoTracking()
                .OrderBy(b => b.Status.Value))
            .ToListAsync(cancellationToken);
}