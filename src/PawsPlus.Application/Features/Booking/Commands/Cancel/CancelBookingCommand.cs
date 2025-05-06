using MediatR;
using PawsPlus.Application.Common;
using PawsPlus.Domain.Errors;
using PawsPlus.Domain.Repositories;
using PawsPlus.Domain.Services;

namespace PawsPlus.Application.Features.Booking.Commands.Cancel;

public class CancelBookingCommand : IRequest<Result>
{
    public string Id { get; set; }
    
    public string SitterId { get; set; }
    
    public string ServiceName { get; set; }
    
    public class CancelBookingCommandHandler(IBookingDomainRepository bookingDomainRepository,
        IEmailSender emailSender) 
        : IRequestHandler<CancelBookingCommand, Result>
    {
        public async Task<Result> Handle(CancelBookingCommand request,
            CancellationToken cancellationToken)
        {
            var booking = await bookingDomainRepository.Find(request.Id);

            if (booking == null)
            {
                return BookingErrors.BookingNotFound(request.Id);
            }

            // if (booking.IsAlreadyResolved())
            // {
            //     return BookingErrors.BookingAlreadyResolved;
            // }
            
            booking.ChangeState("Canceled");
            await bookingDomainRepository.Update(booking);

            // var result = await emailSender.SendBookingCancelEmail(request.ServiceName,
            //     booking.StartDay, 
            //     booking.StartTime,
            //     request.SitterId);
            //
            // if (result == false)
            // {
            //     return BookingErrors.UnableToSendEmail;
            // }
            
            return Result.Success;
        }
    }
}