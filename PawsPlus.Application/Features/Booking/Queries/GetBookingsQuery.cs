using MediatR;
using PawsPlus.Application.Common;
using PawsPlus.Application.Common.Contracts;
using PawsPlus.Application.Features.Profile;
using PawsPlus.Domain.Errors;

namespace PawsPlus.Application.Features.Booking.Queries;

public class GetBookingsQuery : IRequest<Result<ICollection<BookingOutputModel>>>
{
    public class GetBookingsQueryHandler(IBookingQueryRepository bookingQueryRepository,
        IProfileQueryRepository profileQueryRepository,
        ICurrentUser currentUser) 
        : IRequestHandler<GetBookingsQuery, Result<ICollection<BookingOutputModel>>>
    {
        public async Task<Result<ICollection<BookingOutputModel>>> Handle(GetBookingsQuery request, CancellationToken cancellationToken)
        { 
            var sitterId = currentUser.UserId;
            sitterId = await profileQueryRepository.GetProfileIdByUser(sitterId);

            var bookings = await bookingQueryRepository.GetPendingBookings(sitterId);

            if (bookings == null)
            {
                return BookingErrors.NoPendingBookings; 
            }

            return Result<ICollection<BookingOutputModel>>.SuccessWith(bookings);
        }
    }
}