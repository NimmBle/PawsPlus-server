using MediatR;
using PawsPlus.Application.Common;
using PawsPlus.Domain.Enums;
using PawsPlus.Domain.Enums.Pet;
using PawsPlus.Domain.Repositories;

namespace PawsPlus.Application.Features.Post.Commands.Create;

public class CreatePostCommand : PostInputModel, IRequest<Result>
{
    public List<ServiceType> Services { get; set; }
    public List<PetType> Pets { get; set; }
    public string profileId { get; set; }
    
    public class CreatePostCommandHandler(
        IPostDomainRepository postRepository,
        IProfileDomainRepository profileDomainRepository)
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

            var profile = await profileDomainRepository.Find(request.profileId);
            profile.UpdateFirstLogin();
            await profileDomainRepository.Update(profile, cancellationToken);
            
            return true;
        }
    }
}