using MediatR;
using PawsPlus.Application.Common;
using PawsPlus.Application.Common.Contracts;
using PawsPlus.Domain.Errors;
using PawsPlus.Domain.Factories.Pet;
using PawsPlus.Domain.Repositories;

namespace PawsPlus.Application.Features.Pet.Commands.Create;

public class CreatePetCommand 
    : CreatePetInputModel,
        IRequest<Result<CreatePetOutputModel>>
{
    public class CreatePetCommandHandler(
        ICurrentUser currentUser,
        IProfileDomainRepository profileDomainRepository,
        IPetDomainRepository petDomainRepository,
        IBreedDomainRepository breedDomainRepository,
        IAnimalTypeDomainRepository animalTypeDomainRepository,
        IWeightDomainRepository weightDomainRepository,
        IPetFactory petFactory)
        : IRequestHandler<CreatePetCommand, Result<CreatePetOutputModel>>
    {
        public async Task<Result<CreatePetOutputModel>> Handle(
            CreatePetCommand request,
            CancellationToken cancellationToken)
        {
            var profile = await profileDomainRepository.FindByUser(currentUser.UserId);
            
            if (profile.Id != request.ProfileId)
                return PetErrors.PetAccessNotAllowed;
            
            var breedsIds = request.Breeds.Select(breed => breed.Id);
            var breeds = await breedDomainRepository.FindAll(breedsIds);

            var animalTypes = await animalTypeDomainRepository.Find(request.PetType);

            if (animalTypes == null)
            {
                return PetErrors.PetTypeNotFound;
            }
            
            var petBuilder = petFactory
                .WithName(request.Name)
                .WithPhotoUrl(request.PhotoUrl)
                .WithType(animalTypes)
                .WithAge(request.Age.Years, request.Age.Months)
                .WithGender(request.Gender)
                .WithBreed(breeds)
                .WithPersonality(
                    request.Personality.Temperament,
                    request.Personality.ActivityLevel,
                    request.Personality.IsTrained,
                    request.Personality.HasFears,
                    request.Personality.FearsDescription)
                .WithHealthStatus(
                    request.HealthStatus.IsVaccinated,
                    request.HealthStatus.IsCastrated,
                    request.HealthStatus.TakesMedications,
                    request.HealthStatus.HasEatingSchedule,
                    request.HealthStatus.OtherDietaryNeeds,
                    request.HealthStatus.HealthProblems)
                .WithProfileId(profile.Id);
            
            var weight = await weightDomainRepository.Find(request.Weight);
            
            if (request.Weight != null)
            {
                petBuilder.WithWeight(weight);
            }
            
            var pet = petBuilder.Build();


            await petDomainRepository.Save(pet, cancellationToken);

            return new CreatePetOutputModel(pet.Id);
        }
    }
}