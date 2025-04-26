using PawsPlus.Application.Features.Booking.Queries;

namespace PawsPlus.Application.Features.Booking;

public interface IBookingQueryRepository
{
    Task<ICollection<BookingOutputModel>> GetPendingBookings(string id, CancellationToken cancellationToken = default);
    
    Task<int> GetCompletedBookingsByProfileIds(string ownerId, string sitterId, CancellationToken cancellationToken = default);
}