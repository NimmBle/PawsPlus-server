using MediatR;
using PawsPlus.Application.Common;
using PawsPlus.Domain.Errors;
using PawsPlus.Domain.Models;
using PawsPlus.Domain.Repositories;
using PawsPlus.Domain.Services;

namespace PawsPlus.Application.Features.Booking.Commands.Start;

public class StartBookingCommand : IRequest<Result>
{
    public string Id { get; set; }
    
    public class StartBookingCommandHandler(IBookingDomainRepository bookingDomainRepository,
        IEmailSender emailSender) 
        : IRequestHandler<StartBookingCommand, Result>
    {
        public async Task<Result> Handle(StartBookingCommand request,
            CancellationToken cancellationToken)
        {
            var booking = await bookingDomainRepository.Find(request.Id);
            
            if (booking == null)
            {
                return BookingErrors.BookingNotFound(request.Id);
            }
            
            if (booking.StartDay != DateOnly.FromDateTime(DateTime.Now) ||
                (booking.StartDay == DateOnly.FromDateTime(DateTime.Now) && booking.StartTime > TimeOnly.FromDateTime(DateTime.Now)))
            {
                return BookingErrors.CannotStartBooking();
            }

            if (booking.Status.Value != BookingState.Approved.Value)
            {
                return BookingErrors.BookingAlreadyResolved;
            }
            
            booking.ChangeState("Started");
            await bookingDomainRepository.Update(booking);
    
            await emailSender.SendBookingStartEmail(booking.StartDay,
                booking.StartTime,
                booking.OwnerId,
                booking.SitterId);
            
            return Result.Success;
        }
    }
}