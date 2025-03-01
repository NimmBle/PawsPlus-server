using MediatR;
using PawsPlus.Application.Common;
using PawsPlus.Application.Common.Contracts;
using PawsPlus.Application.Features.Profile;

namespace PawsPlus.Application.Features.Booking.Queries;

public class GetBookingsQuery : IRequest<Result<ICollection<BookingOutputModel>>>
{
    public class GetBookingsQueryHandler(IBookingQueryRepository bookingQueryRepository,
        IProfileQueryRepository profileQueryRepository,
        ICurrentUser currentUser) 
        : IRequestHandler<GetBookingsQuery, Result<ICollection<BookingOutputModel>>>
    {
        public async Task<Result<ICollection<BookingOutputModel>>> Handle(GetBookingsQuery request,
            CancellationToken cancellationToken)
        { 
            var id = currentUser.UserId;
            id = await profileQueryRepository.GetProfileIdByUser(id);

            var bookings = await bookingQueryRepository.GetPendingBookings(id);

            if (bookings == null)
            {
                return Result<ICollection<BookingOutputModel>>.SuccessWith(new List<BookingOutputModel>());
            }

            return Result<ICollection<BookingOutputModel>>.SuccessWith(bookings);
        }
    }
}