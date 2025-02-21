using MediatR;
using PawsPlus.Application.Common;
using PawsPlus.Domain.Errors;
using PawsPlus.Domain.Repositories;

namespace PawsPlus.Application.Features.Service.Commands.Edit;

public class EditServiceCommand : EditServiceInputModel, IRequest<Result>
{
    public class EditServiceCommandHandler(
        IServiceDomainRepository serviceDomainRepository)
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
            
            service.UpdatePrice(request.Price);
            service.UpdateAvailableDates(request.AvailableDates);
            service.UpdateMeetingPlaces(request.MeetingPlaces.ToList());
            
            await serviceDomainRepository.Update(service);

            return Result.Success;
        }
    }
}