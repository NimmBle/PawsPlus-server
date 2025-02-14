using MediatR;
using PawsPlus.Application.Common;
using PawsPlus.Application.Common.Contracts;
using PawsPlus.Application.Features.Service;
using PawsPlus.Domain.Repositories;

namespace PawsPlus.Application.Features.Booking.Commands.Create;

public class CreateBookingCommand : CreateBookingInputModel, IRequest<Result>
{
    
    public class CreateBookingCommandHandler(IBookingDomainRepository bookingDomainRepository,
        IServiceQueryRepository serviceQueryRepository,
        ICurrentUser currentUser) 
        : IRequestHandler<CreateBookingCommand, Result>
    {
        public async Task<Result> Handle(CreateBookingCommand request, CancellationToken cancellationToken)
        {
            var serviceId = await serviceQueryRepository.GetServiceId(request.SitterId, request.ServiceType.ToString());

            if (serviceId == null)
                return Result.Failure("No service of this type is found");

            var booking = new Domain.Models.Booking(request.FromDay,
                request.FromTime,
                request.ToDay,
                request.ToTime,
                request.MeetingPlaceType,
                request.MeetingPlaceLocation,
                request.AdditionalDescription,
                serviceId,
                request.SitterId,
                currentUser.UserId);

            await bookingDomainRepository.Save(booking);
            
            return Result.Success;
        }
    }
}