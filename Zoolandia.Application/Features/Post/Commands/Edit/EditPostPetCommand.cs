using MediatR;
using Zoolandia.Application.Common;
using Zoolandia.Domain.Enums.Pet;
using Zoolandia.Domain.Repositories;

namespace Zoolandia.Application.Features.Post.Commands.Edit;

public class EditPostPetCommand : PostInputModel, IRequest<Result>
{
    public string Id { get; set; }
    public PetType Pet { get; set; }
    
    public class EditPostCommandHandler(IPostDomainRepository postDomainRepository)
        : IRequestHandler<EditPostPetCommand, Result>
    {
        public async Task<Result> Handle(EditPostPetCommand request, CancellationToken cancellationToken)
        {
            var post = await postDomainRepository.GetWithoutServices(request.Id);
    
            if (post == null)
                return Result.Failure("Post not found");

            post
                .UpdatePetTypes(request.Pet)
                .UpdateWeights(request.Weights.ToList());
            
            await postDomainRepository.Update(post);
            
            return Result.Success;
        }
    }
}