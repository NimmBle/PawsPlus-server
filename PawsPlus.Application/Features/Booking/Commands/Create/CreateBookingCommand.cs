using MediatR;
using PawsPlus.Application.Common;
using PawsPlus.Application.Common.Contracts;
using PawsPlus.Application.Features.Profile;
using PawsPlus.Application.Features.Service;
using PawsPlus.Domain.Errors;
using PawsPlus.Domain.Factories.Booking;
using PawsPlus.Domain.Repositories;
using PawsPlus.Domain.Services;

namespace PawsPlus.Application.Features.Booking.Commands.Create;

public class CreateBookingCommand : CreateBookingInputModel, IRequest<Result>
{
    
    public class CreateBookingCommandHandler(IBookingDomainRepository bookingDomainRepository,
        IBookingFactory bookingFactory,
        IServiceQueryRepository serviceQueryRepository,
        IProfileQueryRepository profileQueryRepository,
        ICurrentUser currentUser,
        IEmailSender emailSender) 
        : IRequestHandler<CreateBookingCommand, Result>
    {
        public async Task<Result> Handle(CreateBookingCommand request, CancellationToken cancellationToken)
        {
            var ownerProfile = await profileQueryRepository.GetPetLocation(currentUser.UserId);
            var serviceId = await serviceQueryRepository.GetServiceId(request.SitterId, request.ServiceType.ToString());

            if (!ownerProfile.HasPet)
            {
                return BookingErrors.OwnerPetIsNull;
            }
            
            if (serviceId == null)
            {
                return ServiceErrors.ServiceNotFound;
            }

            var booking = bookingFactory
                .WithStartDay(request.StartDay)
                .WithStartTime(request.StartTime)
                .WithEndDay(request.EndDay)
                .WithEndTime(request.EndTime)
                .WithMeetingPlaceType(request.MeetingPlaceType)
                .WithAdditionalDescription(request.AdditionalDescription)
                .WithServiceId(serviceId)
                .WithSitterId(request.SitterId)
                .WithOwnerId(ownerProfile.OwnerId);

            if (request.MeetingPlaceType.Equals(Domain.Enums.MeetingPlaceType.AtOwnersPlace))
            {
                booking = booking
                    .WithMeetingPlaceId(ownerProfile.PlaceId);
            }
            else
            {
                booking = booking
                    .WithMeetingPlaceType(request.MeetingPlaceType);
            }
            
            await bookingDomainRepository.Save(booking.Build());

            var sitterUserId = await profileQueryRepository.GetUserIdByProfileId(request.SitterId);
            
            await emailSender.SendRequestEmail(sitterUserId);
            
            return Result.Success;
        }
    }
}