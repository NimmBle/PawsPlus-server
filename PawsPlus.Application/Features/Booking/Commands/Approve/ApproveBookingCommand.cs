using MediatR;
using PawsPlus.Application.Common;
using PawsPlus.Domain.Repositories;
using PawsPlus.Domain.Services;

namespace PawsPlus.Application.Features.Booking.Commands.Approve;

public class ApproveBookingCommand : IRequest<Result>
{
    public string Id { get; set; }
    
    public string OwnerId { get; set; }
    
    
    public class ApproveBookingCommandHandler(IBookingDomainRepository bookingDomainRepository,
        IEmailSender emailSender) 
        : IRequestHandler<ApproveBookingCommand, Result>
    {
        public async Task<Result> Handle(ApproveBookingCommand request, CancellationToken cancellationToken)
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

            booking.ChangeState("Approved");
            await bookingDomainRepository.Update(booking);
            
            var result = await emailSender.SendBookingApproveEmail(request.OwnerId);

            if (result == false)
            {
                return "Unable to send booking approval email";
            }
            
            return Result.Success;
        }
    }
}