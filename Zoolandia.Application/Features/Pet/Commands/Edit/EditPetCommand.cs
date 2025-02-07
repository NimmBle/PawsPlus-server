using AutoMapper;
using MediatR;
using Zoolandia.Application.Common;
using Zoolandia.Domain.Enums.Pet;
using Zoolandia.Domain.Repositories;
using Zoolandia.Domain.ValueObjects;

namespace Zoolandia.Application.Features.Pet.Commands.Edit;

public class EditPetCommand 
    : EditPetInputModel,
        IRequest<Result>
{
    public string? Id { get; set; }
    
    public class EditPetCommandHandler
        (IPetDomainRepository petDomainRepository,
            IBreedDomainRepository breedDomainRepository,
            IMapper mapper)
        : IRequestHandler<EditPetCommand, Result>
    {
        public async Task<Result> Handle(EditPetCommand request, CancellationToken cancellationToken)
        {
            var pet = await petDomainRepository.Find(request.Id);

            if (pet == null)
                return false;

            var breeds = new HashSet<Domain.Models.Breed>();
            foreach (var breed in request.Breeds)
            {
                breeds.Add(await breedDomainRepository.Find(breed.Id));
            }
            
            pet.Update(
                request.Name,
                request.PhotoUrl,
                request.PetType,
                mapper.Map<Age>(request.Age),
                request.Gender,
                breeds,
                request.Weight,
                mapper.Map<Personality>(request.Personality),
                mapper.Map<HealthStatus>(request.HealthStatus));

            await petDomainRepository.Update(pet, cancellationToken);
            
            return true;

        }
    }
}