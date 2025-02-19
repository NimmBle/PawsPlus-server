using MediatR;
using PawsPlus.Application.Common;
using PawsPlus.Domain.Common;
using PawsPlus.Domain.Errors;
using PawsPlus.Domain.Repositories;
using PawsPlus.Domain.Services;

namespace PawsPlus.Application.Features.Booking.Commands.Disapprove;

public class DisapproveBookingCommand : IRequest<Result>
{
    public string Id { get; set; }
    
    public string OwnerId { get; set; }
    
    
    public class DisapproveBookingCommandHandler(IBookingDomainRepository bookingDomainRepository,
        IEmailSender emailSender)
        : IRequestHandler<DisapproveBookingCommand, Result>
    {
        public async Task<Result> Handle(DisapproveBookingCommand request, CancellationToken cancellationToken)
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

            var result = await emailSender.SendBookingDisapproveEmail(request.OwnerId);

            if (result == false)
            {
                return BookingErrors.UnableToSendEmail;
            }
            
            return Result.Success;
        }
    }
}