using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PawsPlus.Application.Common;
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
    public async Task<Booking?> Find(string id,
        CancellationToken cancellationToken = default)
        => await this
            .All()
            .FirstOrDefaultAsync(b => b.Id == id, cancellationToken);

    public async Task<Booking?> FindByServiceId(string serviceId,
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

    public async Task<bool> HasCompletedBookings(string ownerId, string sitterId, CancellationToken cancellationToken = default)
        => await this
            .All()
            .Where(b => b.OwnerId == ownerId &&
                        b.SitterId == sitterId && 
                        b.Status.Value == BookingState.Completed.Value)
            .AnyAsync();

    public async Task<bool> AlreadyCreated(string ownerId,
        string sitterId,
        DateOnly startDate,
        TimeOnly startTime,
        DateOnly endDate,
        TimeOnly endTime,
        CancellationToken cancellationToken = default)
        => await this
            .All()
            .Where(b => b.OwnerId == ownerId &&
                        b.SitterId == sitterId &&
                        b.StartDay.Day == startDate.Day &&
                        b.EndDay.Day == endDate.Day &&
                        b.Status.Value == BookingState.Approved.Value &&
                        (startTime.IsBetween(b.StartTime, b.EndTime) ||
                        endTime.IsBetween(b.StartTime, b.EndTime)))
            .AnyAsync(cancellationToken);
}