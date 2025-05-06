using MediatR;
using PawsPlus.Application.Common;
using PawsPlus.Domain.Errors;
using PawsPlus.Domain.Repositories;
using PawsPlus.Domain.Services;

namespace PawsPlus.Application.Features.Booking.Commands.Disapprove;

public class DisapproveBookingCommand : IRequest<Result>
{
    public string Id { get; set; }
    
    public string OwnerId { get; set; }
    
    public string ServiceName { get; set; }
    
    public class DisapproveBookingCommandHandler(IBookingDomainRepository bookingDomainRepository,
        IEmailSender emailSender)
        : IRequestHandler<DisapproveBookingCommand, Result>
    {
        public async Task<Result> Handle(DisapproveBookingCommand request,
            CancellationToken cancellationToken)
        {
            var booking = await bookingDomainRepository.Find(request.Id);

            if (booking == null)
            {
                return BookingErrors.BookingNotFound(request.Id);
            }

            if (booking.IsAlreadyResolved())
            {
                return BookingErrors.BookingAlreadyResolved;
            }
            
            booking.ChangeState("Disapproved");
            await bookingDomainRepository.Update(booking);

            await emailSender.SendBookingDisapproveEmail(request.ServiceName,
                booking.StartDay, 
                booking.StartTime,
                request.OwnerId);
            
            return Result.Success;
        }
    }
}