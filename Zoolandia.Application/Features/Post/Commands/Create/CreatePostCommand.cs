using MediatR;
using Zoolandia.Application.Common;
using Zoolandia.Domain.Enums;
using Zoolandia.Domain.Enums.Pet;
using Zoolandia.Domain.Repositories;

namespace Zoolandia.Application.Features.Post.Commands.Create;

public class CreatePostCommand : PostInputModel, IRequest<Result>
{
    public HashSet<ServiceType> Services { get; set; }
    public HashSet<PetType> Pets { get; set; }
    public string profileId { get; set; }
    
    public class CreatePostCommandHandler(
        IPostDomainRepository postRepository,
        IServiceDomainRepository serviceRepository)
        : IRequestHandler<CreatePostCommand, Result>
    {
        public async Task<Result> Handle(
            CreatePostCommand request,
            CancellationToken cancellationToken)
        {
            var post = new Domain.Models.Post(
                request.Pets,
                request.Weights,
                request.profileId
                );
            
            post.AddServices(request.Services);
            
            await postRepository.Save(post, cancellationToken);

            return true;
        }
    }
}