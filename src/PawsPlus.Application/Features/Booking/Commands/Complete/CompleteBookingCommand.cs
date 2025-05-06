using MediatR;
using PawsPlus.Application.Common;
using PawsPlus.Domain.Errors;
using PawsPlus.Domain.Models;
using PawsPlus.Domain.Repositories;
using PawsPlus.Domain.Services;

namespace PawsPlus.Application.Features.Booking.Commands.Complete;

public class CompleteBookingCommand : IRequest<Result>
{
    
    public string Id { get; set; }
    
    public class CompleteBookingCommandhHandler(IBookingDomainRepository bookingDomainRepository,
        IEmailSender emailSender) 
        : IRequestHandler<CompleteBookingCommand, Result>
    {
        public async Task<Result> Handle(CompleteBookingCommand request,
            CancellationToken cancellationToken)
        {
            var booking = await bookingDomainRepository.Find(request.Id);
            if (booking == null)
            {
                return BookingErrors.BookingNotFound(request.Id);
            }

            if (booking.EndDay != DateOnly.FromDateTime(DateTime.Now) ||
                (booking.EndDay == DateOnly.FromDateTime(DateTime.Now) && booking.EndTime > TimeOnly.FromDateTime(DateTime.Now)))
            {
                return BookingErrors.CannotCompleteBooking();
            }
            
            if (booking.Status.Value != BookingState.Started.Value)
            {
                return BookingErrors.BookingAlreadyResolved;
            }
            
            booking.ChangeState("Completed");
            await bookingDomainRepository.Update(booking);

            await emailSender.SendBookingCompleteEmail(booking.StartDay, 
                booking.StartTime,
                booking.OwnerId,
                booking.SitterId,
                cancellationToken);
            
            return Result.Success;
        }
    }
}