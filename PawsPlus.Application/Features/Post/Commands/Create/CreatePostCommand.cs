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
        IProfileDomainRepository profileDomainRepository,
        IAnimalTypeDomainRepository animalTypeDomainRepository)
        : IRequestHandler<CreatePostCommand, Result>
    {
        public async Task<Result> Handle(
            CreatePostCommand request,
            CancellationToken cancellationToken)
        {
            var animalTypes = await animalTypeDomainRepository.FindAll(request.Pets);
            
            var post = new Domain.Models.Post(
                animalTypes,
                request.Weights,
                request.profileId
                );
            
            post.AddServices(request.Services);
            await postRepository.Save(post, cancellationToken);

            var profile = await profileDomainRepository.Find(request.profileId);
            profile.UpdateFirstLogin();
            await profileDomainRepository.Update(profile, cancellationToken);
            
            return Result.Success;
        }
    }
}