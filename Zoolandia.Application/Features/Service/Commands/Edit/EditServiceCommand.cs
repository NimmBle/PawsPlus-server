using MediatR;
using Zoolandia.Application.Common;
using Zoolandia.Domain.Repositories;

namespace Zoolandia.Application.Features.Service.Commands.Edit;

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
            var service = await serviceDomainRepository.Find(request.Id);

            service.UpdatePrice(request.Price);
            service.UpdateAvailableDates(request.AvailableDates);
            
            await serviceDomainRepository.Update(service);

            return Result.Success;
        }
    }
}