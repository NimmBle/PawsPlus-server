using MediatR;
using Zoolandia.Application.Common;
using Zoolandia.Domain.Repositories;

namespace Zoolandia.Application.Features.Service.Commands.Create;

public class CreateServiceCommand : CreateServiceInputModel, IRequest<Result<string>>
{
    public class CreatePostServiceCommandHandler(
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
            
            var service = new Domain.Models.Service()
            {
                Id = Guid.NewGuid().ToString(),
                Name = request.ServiceType.ToString(),
                Price = request.Price,
                AvailableDates = request.AvailableDates,
                PostId = request.PostId,
            };

            await serviceRepository.Save(service);

            return Result<string>.SuccessWith(service.Id);
        }
    }
}