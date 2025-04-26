using MediatR;
using PawsPlus.Application.Common;

namespace PawsPlus.Application.Features.Booking.Queries.Completed;

public class GetCompletedBookingsQuery : IRequest<Result<bool>>
{
    public string sitterId { get; set; }
    
    public string ownerId { get; set; }
    
    public class GetCompletedBookingsQueryHandler(IBookingQueryRepository bookingQueryRepository)
        : IRequestHandler<GetCompletedBookingsQuery, Result<bool>>
    {
        public async Task<Result<bool>> Handle(GetCompletedBookingsQuery request,
            CancellationToken cancellationToken)
            => await bookingQueryRepository.HasCompletedBookings(request.ownerId, request.sitterId);
    }
}