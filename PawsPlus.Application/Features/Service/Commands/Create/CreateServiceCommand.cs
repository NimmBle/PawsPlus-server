using MediatR;
using PawsPlus.Application.Common;
using PawsPlus.Domain.Repositories;

namespace PawsPlus.Application.Features.Service.Commands.Create;

public class CreateServiceCommand : CreateServiceInputModel, IRequest<Result<string>>
{
    public class CreateServiceCommandHandler(
        IServiceDomainRepository serviceRepository) 
        : IRequestHandler<CreateServiceCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(
            CreateServiceCommand request,
            CancellationToken cancellationToken)
        {
            var alreadyExists = await serviceRepository.AlreadyExists(request.ServiceType.ToString(), request.PostId);
            
            if (alreadyExists)
                return Result<string>.Failure("Service already exists");

            var service = new Domain.Models.Service(
                request.ServiceType,
                request.Price,
                request.AvailableDates,
                request.PostId); 
            
            await serviceRepository.Save(service);

            return Result<string>.SuccessWith(service.Id);
        }
    }
}