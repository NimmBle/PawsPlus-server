using PawsPlus.Application.Features.Booking.Queries;

namespace PawsPlus.Application.Features.Booking;

public interface IBookingQueryRepository
{
    Task<ICollection<BookingOutputModel>> GetPendingBookings(string sitterId,
        CancellationToken cancellationToken = default);
}