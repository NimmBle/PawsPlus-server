using MediatR;
using PawsPlus.Application.Common;
using PawsPlus.Domain.Common;
using PawsPlus.Domain.Enums.Pet;
using PawsPlus.Domain.Errors;
using PawsPlus.Domain.Models;
using PawsPlus.Domain.Repositories;

namespace PawsPlus.Application.Features.Post.Commands.Delete;

public sealed class DeletePostPetCommand : EntityCommand<string>, IRequest<Result>
{
    public int AnimalTypeId { get; set; }
    
    public sealed class DeletePostPetCommandHandler(IPostDomainRepository postDomainRepository,
        IAnimalTypeDomainRepository animalTypeDomainRepository)
        : IRequestHandler<DeletePostPetCommand, Result>
    {
        public async Task<Result> Handle(DeletePostPetCommand request, CancellationToken cancellationToken)
        {
            if (request.AnimalTypeId == null)
            {
                return Error.NullValue;
            }
            
            var post = await postDomainRepository.Find(request.Id);
            if (post == null)
            {
                return PostErrors.PostNotFound(request.Id); 
            }
            
            var animalType = await animalTypeDomainRepository.Find(request.AnimalTypeId);
            if (animalType == null)
            {
                return PostErrors.PostAnimalTypeNotFound;
            }
            
            post.RemoveAnimalType(animalType);
            
            await postDomainRepository.Update(post);
            
            return Result.Success;
        }
    }
}