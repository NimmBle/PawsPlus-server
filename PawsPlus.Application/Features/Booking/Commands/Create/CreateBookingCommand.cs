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
        IMeetingPlaceDomainRepository meetingPlaceDomainRepository,
        ICurrentUser currentUser,
        IEmailSender emailSender) 
        : IRequestHandler<CreateBookingCommand, Result>
    {
        public async Task<Result> Handle(CreateBookingCommand request, CancellationToken cancellationToken)
        {
            var ownerProfile = await profileQueryRepository.GetPetLocation(currentUser.UserId);
            var service = await serviceQueryRepository.GetServiceId(request.SitterId, request.ServiceType.ToString());

            if (!ownerProfile.HasPet)
            {
                return BookingErrors.OwnerPetIsNull;
            }
            
            if (service.Id == null)
            {
                return ServiceErrors.ServiceNotFound;
            }

            if (!service.AvailableDates.Contains(request.StartDay) ||
                !service.AvailableDates.Contains(request.EndDay))
            {
                return ServiceErrors.InvalidAvailableDates;
            }

            if (!service.MeetingPlaces.Contains(request.MeetingPlaceType))
            {
                return ServiceErrors.NonExistingMeetingPlace;
            }
            
            var meetingPlace = await meetingPlaceDomainRepository.Find(request.MeetingPlaceType);

            var booking = bookingFactory
                .WithStartDay(request.StartDay)
                .WithStartTime(request.StartTime)
                .WithEndDay(request.EndDay)
                .WithEndTime(request.EndTime)
                .WithMeetingPlace(meetingPlace)
                .WithAdditionalDescription(request.AdditionalDescription)
                .WithServiceId(service.Id)
                .WithSitterId(request.SitterId)
                .WithOwnerId(ownerProfile.OwnerId);

            if (request.MeetingPlaceType == 1)
            {
                booking = booking
                    .WithGooglePlaceId(ownerProfile.PlaceId);
            }
            else
            {
                booking = booking
                    .WithGooglePlaceId(request.MeetingPlaceId);
            }

            var bookingBuild = booking.Build();
            await bookingDomainRepository.Save(bookingBuild);

            var sitterUserId = await profileQueryRepository.GetUserIdByProfileId(request.SitterId);
            
            await emailSender.SendRequestEmail(sitterUserId);
            
            return Result.Success;
        }
    }
}