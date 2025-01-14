using MediatR;
using Zoolandia.Application.Common;
using Zoolandia.Domain.Enums;
using Zoolandia.Domain.Repositories;

namespace Zoolandia.Application.Features.PostService.Commands;

public class CreatePostServiceCommand : PostServiceInputModel, IRequest<Result<string>>
{
    public ServiceType serviceTypeId { get; set; }
    
    public class CreatePostServiceCommandHandler(
        IPostServiceDomainRepository postServiceRepository,
        IServiceDomainRepository serviceRepository) 
        : IRequestHandler<CreatePostServiceCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(
            CreatePostServiceCommand request,
            CancellationToken cancellationToken)
        {
            var serviceId = await serviceRepository.GetIdOfService(request.serviceTypeId.ToString());
            
            var postService = new Domain.Models.PostService()
            {
                Id = Guid.NewGuid().ToString(),
                Price = request.Price,
                AvailableDates = request.AvailableDates,
                ServiceId = serviceId,
                PostId = request.Id,
            };

            await postServiceRepository.Save(postService);

            return Result<string>.SuccessWith(postService.Id);
        }
    }
}