using MediatR;
using PawsPlus.Application.Common;
using PawsPlus.Domain.Enums;
using PawsPlus.Domain.Enums.Pet;
using PawsPlus.Domain.Models;
using PawsPlus.Domain.Repositories;

namespace PawsPlus.Application.Features.Post.Commands.Create;

public class CreatePostCommand : PostInputModel, IRequest<Result>
{
    public List<ServiceType> Services { get; set; }
    public List<int> Pets { get; set; }
    public string profileId { get; set; }
    
    public class CreatePostCommandHandler(
        IPostDomainRepository postRepository,
        IAnimalTypeDomainRepository animalTypeDomainRepository,
        IWeightDomainRepository weightDomainRepository)
        : IRequestHandler<CreatePostCommand, Result>
    {
        public async Task<Result> Handle(
            CreatePostCommand request,
            CancellationToken cancellationToken)
        {
            var animalTypes = await animalTypeDomainRepository.FindAll(request.Pets);
            var weights = await weightDomainRepository.FindAll(request.Weights);
            
            var post = new Domain.Models.Post(
                animalTypes,
                weights.ToList(),
                request.profileId
                );
            
            post.AddServices(request.Services);
            await postRepository.Save(post, cancellationToken);
            
            return Result.Success;
        }
    }
}