using MediatR;
using PawsPlus.Application.Common;
using PawsPlus.Application.Common.Contracts;
using PawsPlus.Domain.Errors;
using PawsPlus.Domain.Factories;
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

            var breeds = new List<Domain.Models.Breed>();
            foreach (var breed in request.Breeds)
            {
                breeds.Add(await breedDomainRepository.Find(breed.Id));
            }
            
            var pet = petFactory
                .WithName(request.Name)
                .WithPhotoUrl(request.PhotoUrl)
                .WithType(request.PetType)
                .WithAge(request.Age.Years, request.Age.Months)
                .WithGender(request.Gender)
                .WithBreed(breeds)
                .WithWeight(request.Weight)
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
                .WithProfileId(profile.Id)
                .Build();

            await petDomainRepository.Save(pet, cancellationToken);

            return new CreatePetOutputModel(pet.Id);
        }
    }
}