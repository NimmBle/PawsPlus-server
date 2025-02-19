using MediatR;
using PawsPlus.Application.Common;
using PawsPlus.Application.Common.Contracts;
using PawsPlus.Application.Features.Profile;
using PawsPlus.Application.Features.Service;
using PawsPlus.Domain.Errors;
using PawsPlus.Domain.Repositories;
using PawsPlus.Domain.Services;

namespace PawsPlus.Application.Features.Booking.Commands.Create;

public class CreateBookingCommand : CreateBookingInputModel, IRequest<Result>
{
    
    public class CreateBookingCommandHandler(IBookingDomainRepository bookingDomainRepository,
        IServiceQueryRepository serviceQueryRepository,
        IProfileQueryRepository profileQueryRepository,
        ICurrentUser currentUser,
        IEmailSender emailSender) 
        : IRequestHandler<CreateBookingCommand, Result>
    {
        public async Task<Result> Handle(CreateBookingCommand request, CancellationToken cancellationToken)
        {
            var currentUserId = currentUser.UserId;
            var ownerProfileId = await profileQueryRepository.GetProfileIdByUser(currentUserId);
            
            
            var serviceId = await serviceQueryRepository.GetServiceId(request.SitterId, request.ServiceType.ToString());

            if (serviceId == null)
            {
                return ServiceErrors.ServiceNotFound;
            }
            
            var booking = new Domain.Models.Booking(request.StartDay,
                request.StartTime,
                request.EndDay,
                request.EndTime,
                request.MeetingPlaceType,
                request.MeetingPlaceId,
                request.AdditionalDescription,
                serviceId,
                request.SitterId,
                ownerProfileId);

            await bookingDomainRepository.Save(booking);

            var sitterUserId = await profileQueryRepository.GetUserIdByProfileId(request.SitterId);
            
            var requestResult = await emailSender.SendRequestEmail(sitterUserId);

            if (!requestResult)
            {
                return BookingErrors.UnableToSendEmail;
            }
            
            return Result.Success;
        }
    }
}