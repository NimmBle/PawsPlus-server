using MediatR;
using Zoolandia.Application.Common;
using Zoolandia.Domain.Repositories;

namespace Zoolandia.Application.Features.Service.Commands.Create;

public class CreateServiceCommand : CreateServiceInputModel, IRequest<Result<string>>
{
    public class CreatePostServiceCommandHandler(IServiceDomainRepository serviceRepository) 
        : IRequestHandler<CreateServiceCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(
            CreateServiceCommand request,
            CancellationToken cancellationToken)
        {
            var service = new Domain.Models.Service()
            {
                Id = Guid.NewGuid().ToString(),
                Name = request.ServiceType.ToString(),
                Price = request.Price,
                AvailableDates = request.AvailableDates,
                PostId = request.Id,
            };

            await serviceRepository.Save(service);

            return Result<string>.SuccessWith(service.Id);
        }
    }
}