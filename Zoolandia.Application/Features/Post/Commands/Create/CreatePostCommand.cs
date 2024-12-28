using MediatR;
using Zoolandia.Application.Common;
using Zoolandia.Application.Features.Service;
using Zoolandia.Domain.Enums;
using Zoolandia.Domain.Enums.Pet;
using Zoolandia.Domain.Models;
using Zoolandia.Domain.Repositories;

namespace Zoolandia.Application.Features.Post.Commands.Create;

public class CreatePostCommand : IRequest<Result>
{
    public ICollection<PetType> Pets { get; set; }
    public ICollection<Weight> Weights { get; set; }
    public ICollection<ServiceType> Services { get; set; }
    public string profileId { get; set; }
    
    public class CreatePostCommandHandler(
        IPostDomainRepository postRepository,
        IServiceDomainRepository serviceDomainRepository,
        IServiceQueryRepository serviceQueryRepository)
        : IRequestHandler<CreatePostCommand, Result>
    {
        public async Task<Result> Handle(
            CreatePostCommand request,
            CancellationToken cancellationToken)
        {
            var post = new Domain.Models.Post
            {
                Id = Guid.NewGuid().ToString(),
                Pets = request.Pets,
                Weights = request.Weights,
                ProfileId = request.profileId,
                
            };
            foreach (var serviceType in request.Services)
            {
                var service = await serviceQueryRepository.GetServiceByName(serviceType.ToString());
                post.Services.Add(service);
            }
            
            await postRepository.Save(post, cancellationToken);


            // foreach (var serviceType in request.Services)
            // {
            //     var service = new Service
            //     {
            //         Id = Guid.NewGuid().ToString(),
            //         Name = serviceType.ToString()
            //     };
            //     
            //     await serviceRepository.Save(service, cancellationToken);
            // }

            return true;
        }
    }
}