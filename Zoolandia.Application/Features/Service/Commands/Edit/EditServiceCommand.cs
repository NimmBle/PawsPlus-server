using MediatR;
using Zoolandia.Application.Common;
using Zoolandia.Domain.Repositories;

namespace Zoolandia.Application.Features.Service.Commands.Edit;

public class EditServiceCommand : EditServiceInputModel, IRequest<Result>
{
    public class EditServiceCommandHandler(
        IServiceDomainRepository serviceRepository)
        : IRequestHandler<EditServiceCommand, Result>
    {
        public async Task<Result> Handle(
            EditServiceCommand request,
            CancellationToken cancellationToken)
        {
            var service = await serviceRepository.GetById(request.Id);
                
            service.Price = request.Price;
            service.AvailableDates = request.AvailableDates;

            await serviceRepository.Update(service);

            return true;
        }
    }
}