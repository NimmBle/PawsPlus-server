using MediatR;
using PawsPlus.Application.Common;
using PawsPlus.Domain.Repositories;
using PawsPlus.Domain.Services;

namespace PawsPlus.Application.Features.Booking.Commands.Cancel;

public class CancelBookingCommand : IRequest<Result>
{
    public string Id { get; set; }
    
    public string SitterId { get; set; }
    
    
    public class CancelBookingCommandHandler(IBookingDomainRepository bookingDomainRepository,
        IEmailSender emailSender) 
        : IRequestHandler<CancelBookingCommand, Result>
    {
        public async Task<Result> Handle(CancelBookingCommand request, CancellationToken cancellationToken)
        {
            var booking = await bookingDomainRepository.Find(request.Id);

            if (booking == null)
            {
                return "No booking found";
            }

            if (booking.IsAlreadyResolved())
            {
                return "Booking is already resolved";
            }
            
            booking.ChangeState("Canceled");
            await bookingDomainRepository.Update(booking);

            var result = await emailSender.SendBookingCancelEmail(request.SitterId);

            if (result == false)
            {
                return "Unable to send booking cancellation email";
            }
            
            return Result.Success;
        }
    }
}