using MediatR;
using PawsPlus.Application.Common;
using PawsPlus.Domain.Enums.Pet;
using PawsPlus.Domain.Repositories;

namespace PawsPlus.Application.Features.Post.Commands.Delete;

public sealed class DeletePostPetCommand : EntityCommand<string>, IRequest<Result>
{
    public PetType PetTypeId { get; set; }
    
    public sealed class DeletePostPetCommandHandler(IPostDomainRepository postDomainRepository)
        : IRequestHandler<DeletePostPetCommand, Result>
    {
        public async Task<Result> Handle(DeletePostPetCommand request, CancellationToken cancellationToken)
        {
            if (request.PetTypeId == null)
                return "No pet type specified";
            
            var post = await postDomainRepository.Find(request.Id);
            
            if (post == null) 
                return "Post not found";
            
            post.RemovePetType(request.PetTypeId);
            
            await postDomainRepository.Update(post);
            
            return Result.Success;
        }
    }
}