using MediatR;
using PawsPlus.Application.Common;
using PawsPlus.Domain.Enums.Pet;
using PawsPlus.Domain.Errors;
using PawsPlus.Domain.Repositories;

namespace PawsPlus.Application.Features.Post.Commands.Edit;

public class EditPostPetCommand : PostInputModel, IRequest<Result>
{
    public string Id { get; set; }
    public int Pet { get; set; }
    
    public class EditPostCommandHandler(IPostDomainRepository postDomainRepository,
        IAnimalTypeDomainRepository animalTypeDomainRepository)
        : IRequestHandler<EditPostPetCommand, Result>
    {
        public async Task<Result> Handle(EditPostPetCommand request, CancellationToken cancellationToken)
        {
            var post = await postDomainRepository.Find(request.Id);

            if (post == null)
            {
                return PostErrors.PostNotFound(request.Id); 
            }

            var animalType = await animalTypeDomainRepository.Find(request.Pet);
            
            post
                .UpdatePetTypes(animalType)
                .UpdateWeights(request.Weights.ToList());
            
            await postDomainRepository.Update(post);
            
            return Result.Success;
        }
    }
}