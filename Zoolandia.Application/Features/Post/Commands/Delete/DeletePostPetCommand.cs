using MediatR;
using Zoolandia.Application.Common;
using Zoolandia.Domain.Enums.Pet;
using Zoolandia.Domain.Repositories;

namespace Zoolandia.Application.Features.Post.Commands.Delete;

public sealed class DeletePostPetCommand : EntityCommand<string>, IRequest<Result>
{
    public PetType PetTypeId { get; set; }
    
    public sealed class DeletePostPetCommandHandler(IPostDomainRepository postDomainRepository)
        : IRequestHandler<DeletePostPetCommand, Result>
    {
        public async Task<Result> Handle(DeletePostPetCommand request, CancellationToken cancellationToken)
        {
            if (request.PetTypeId == null)
                return Result.Failure("No pet type specified");
            
            var post = await postDomainRepository.GetWithoutServices(request.Id);
            
            if (post == null) 
                return Result.Failure("Post not found");
            
            if (!post.PetTypes.Contains(request.PetTypeId))
                return Result.Failure("Post doesn't contain the specified pet type");
            
            post.RemovePetType(request.PetTypeId);
            
            await postDomainRepository.Update(post);
            
            return Result.Success;
        }
    }
}