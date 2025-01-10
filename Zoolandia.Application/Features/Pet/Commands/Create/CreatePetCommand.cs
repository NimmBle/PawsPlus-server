using MediatR;
using Zoolandia.Application.Common;
using Zoolandia.Application.Common.Contracts;
using Zoolandia.Application.Features.Pet.Commands.Common;
using Zoolandia.Domain.Factories;
using Zoolandia.Domain.Repositories;

namespace Zoolandia.Application.Features.Pet.Commands.Create;

public class CreatePetCommand 
    : CreatePetInputModel,
        IRequest<Result<CreatePetOutputModel>>
{
    public class CreatePetCommandHandler(
        ICurrentUser currentUser,
        IProfileDomainRepository profileRepository,
        IPetFactory petFactory,
        IPetDomainRepository petRepository)
        : IRequestHandler<CreatePetCommand, Result<CreatePetOutputModel>>
    {
        public async Task<Result<CreatePetOutputModel>> Handle(
            CreatePetCommand request,
            CancellationToken cancellationToken)
        {
            
            var profile = await profileRepository.GetByUser(currentUser.UserId);

            if (profile.Id != request.ProfileId)
                return "You cannot create a pet for this user";
            
            if (profile == null)
                return "There is no Profile with this id";

            if (request.Age.Years == 0 && request.Age.Months == 0)
                return "Please enter a valid age";
            
            var pet = petFactory
                .WithName(request.Name)
                .WithPhotoUrl(request.PhotoUrl)
                .WithType(request.PetType)
                .WithAge(request.Age.Years, request.Age.Months)
                .WithGender(request.Gender)
                .WithBreed(request.Breed)
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

            await petRepository.Save(pet, cancellationToken);

            return new CreatePetOutputModel(pet.Id);
        }
    }
}