using MediatR;
using PawsPlus.Application.Common;
using PawsPlus.Domain.Errors;
using PawsPlus.Domain.Models;
using PawsPlus.Domain.Repositories;

namespace PawsPlus.Application.Features.Service.Commands.Edit;

public class EditServiceCommand : EditServiceInputModel, IRequest<Result>
{
    public class EditServiceCommandHandler(IServiceDomainRepository serviceDomainRepository,
        IMeetingPlaceDomainRepository meetingPlaceDomainRepository,
        IDateDomainRepository dateDomainRepository)
        : IRequestHandler<EditServiceCommand, Result>
    {
        public async Task<Result> Handle(
            EditServiceCommand request,
            CancellationToken cancellationToken)
        {
            if (request.MeetingPlaces.Count == 0)
            {
                return ServiceErrors.InvalidMeetingPlace;
            }
            
            var service = await serviceDomainRepository.Find(request.Id);
            var meetingPlaces = await meetingPlaceDomainRepository.FindAll(request.MeetingPlaces);

            request.AvailableDates.Sort();
            var count = request.AvailableDates.Count;
            
            var allAvailableDates = await dateDomainRepository.FindAll(request.AvailableDates[0], request.AvailableDates[count-1]);
            
            var availableDates = new List<Date>();
            for (int i = 0; i < request.AvailableDates.Count; i++)
            {
                if (allAvailableDates.Any(d => d.Day == request.AvailableDates[i]))
                {
                    availableDates.Add(allAvailableDates.Where(d => d.Day == request.AvailableDates[i]).SingleOrDefault());
                }
                else
                {
                    availableDates.Add(new Date(request.AvailableDates[i]));
                }
            }
            
            service.UpdatePrice(request.Price);
            service.UpdateAvailableDates(availableDates);
            service.UpdateMeetingPlaces(meetingPlaces);

            await serviceDomainRepository.Update(service);

            return Result.Success;
        }
    }
}