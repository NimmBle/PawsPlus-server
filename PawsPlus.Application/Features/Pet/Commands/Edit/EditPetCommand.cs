using AutoMapper;
using MediatR;
using PawsPlus.Application.Common;
using PawsPlus.Domain.Repositories;
using PawsPlus.Domain.ValueObjects;

namespace PawsPlus.Application.Features.Pet.Commands.Edit;

public class EditPetCommand 
    : EditPetInputModel,
        IRequest<Result>
{
    public string? Id { get; set; }
    
    public class EditPetCommandHandler(IPetDomainRepository petDomainRepository,
            IBreedDomainRepository breedDomainRepository,
            IAnimalTypeDomainRepository animalTypeDomainRepository,
            IWeightDomainRepository weightDomainRepository,
            IMapper mapper)
        : IRequestHandler<EditPetCommand, Result>
    {
        public async Task<Result> Handle(EditPetCommand request,
            CancellationToken cancellationToken)
        {
            var pet = await petDomainRepository.Find(request.Id);

            if (pet == null)
                return false;

            var breedsIds = request.Breeds.Select(breed => breed.Id);
            var breeds = await breedDomainRepository.FindAll(breedsIds);
            
            var animalType = await animalTypeDomainRepository.Find(request.PetType);
            var weight = await weightDomainRepository.Find(request.Weight);

            var healthStatus = mapper.Map<HealthStatus>(request.HealthStatus);
            pet.Update(
                request.Name,
                request.PhotoUrl,
                animalType,
                mapper.Map<Age>(request.Age),
                request.Gender,
                breeds,
                weight,
                mapper.Map<Personality>(request.Personality),
                healthStatus
                );

            await petDomainRepository.Update(pet, cancellationToken);
            
            return true;

        }
    }
}