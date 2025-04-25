using MediatR;
using PawsPlus.Application.Common;
using PawsPlus.Domain.Errors;
using PawsPlus.Domain.Repositories;
using PawsPlus.Domain.Services;

namespace PawsPlus.Application.Features.Booking.Commands.Approve;

public class ApproveBookingCommand : IRequest<Result>
{
    public string Id { get; set; }
    
    public string OwnerId { get; set; }
    
    public string ServiceName { get; set; }
    
    public class ApproveBookingCommandHandler(IBookingDomainRepository bookingDomainRepository,
        IEmailSender emailSender) 
        : IRequestHandler<ApproveBookingCommand, Result>
    {
        public async Task<Result> Handle(ApproveBookingCommand request,
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

            booking.ChangeState("Approved");
            await bookingDomainRepository.Update(booking);
            
            var result = await emailSender.SendBookingApproveEmail(request.ServiceName,
                booking.StartDay, 
                booking.StartTime,
                request.OwnerId);
            
            if (result == false)
            {
                return BookingErrors.UnableToSendEmail;
            }
            
            return Result.Success;
        }
    }
}