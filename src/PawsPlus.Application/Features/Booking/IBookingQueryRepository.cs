using PawsPlus.Application.Common;
using PawsPlus.Application.Features.Booking.Queries;

namespace PawsPlus.Application.Features.Booking;

public interface IBookingQueryRepository
{
    Task<ICollection<BookingOutputModel>> GetPendingBookings(string id, CancellationToken cancellationToken = default);
    
    Task<bool> HasCompletedBookings(string ownerId, string sitterId, CancellationToken cancellationToken = default);
    
    Task<bool> AlreadyCreated(string ownerId, string sitterId, DateOnly startDate, TimeOnly startTime, DateOnly endDate, TimeOnly endTime, CancellationToken cancellationToken = default );
}