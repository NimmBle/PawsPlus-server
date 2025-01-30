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
        IProfileDomainRepository profileDomainRepository,
        IPetDomainRepository petDomainRepository,
        IPetFactory petFactory)
        : IRequestHandler<CreatePetCommand, Result<CreatePetOutputModel>>
    {
        public async Task<Result<CreatePetOutputModel>> Handle(
            CreatePetCommand request,
            CancellationToken cancellationToken)
        {
            var profile = await profileDomainRepository.FindByUser(currentUser.UserId);

            if (profile == null)
                return "There is no Profile with this id";
            
            if (profile.Pet != null) 
                return "Cannot create more than one pet";
            
            if (profile.Id != request.ProfileId)
                return "You cannot create a pet for this user";
            
            var pet = petFactory
                .WithName(request.Name)
                .WithPhotoUrl(request.PhotoUrl)
                .WithType(request.PetType)
                .WithAge(request.Age.Years, request.Age.Months)
                .WithGender(request.Gender)
                .WithBreed(request.Breeds)
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