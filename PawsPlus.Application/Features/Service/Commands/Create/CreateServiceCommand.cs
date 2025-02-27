using MediatR;
using PawsPlus.Application.Common;
using PawsPlus.Domain.Errors;
using PawsPlus.Domain.Models;
using PawsPlus.Domain.Repositories;

namespace PawsPlus.Application.Features.Service.Commands.Create;

public class CreateServiceCommand : CreateServiceInputModel, IRequest<Result>
{
    public class CreateServiceCommandHandler(IServiceDomainRepository serviceDomainRepository,
        IMeetingPlaceDomainRepository meetingPlaceDomainRepository,
        IDateDomainRepository dateDomainRepository) 
        : IRequestHandler<CreateServiceCommand, Result>
    {
        public async Task<Result> Handle(
            CreateServiceCommand request,
            CancellationToken cancellationToken)
        {
            var alreadyExists = await serviceDomainRepository.AlreadyExists(request.ServiceType.ToString(), request.PostId);

            if (alreadyExists)
            {
                return ServiceErrors.ServiceAlreadyExists;
            }

            var meetingPlaces = await meetingPlaceDomainRepository.FindAll(request.MeetingPlaces);

            // var availableDates = new List<Date>();
            // foreach (var date in request.AvailableDates)
            // {
            //     availableDates.Add(new Date(date));
            // }
            
            var count = request.AvailableDates.Count;
            var allAvailableDates = await dateDomainRepository.FindAll(request.AvailableDates[0], request.AvailableDates[count-1]);
            
            var service = new Domain.Models.Service(
                request.ServiceType,
                request.Price,
                request.AvailableDates,
                meetingPlaces,
                request.PostId,
                allAvailableDates); 
            
            await serviceDomainRepository.Save(service);

            return Result.Success;
        }
    }
}