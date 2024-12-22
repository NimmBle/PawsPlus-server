using MediatR;
using Zoolandia.Application.Common;
using Zoolandia.Application.Common.Contracts;
using Zoolandia.Application.Features.Pet.Commands.Common;
using Zoolandia.Domain.Factories;
using Zoolandia.Domain.Repositories;

namespace Zoolandia.Application.Features.Pet.Commands.Create;

public class CreatePetCommand 
    : PetCommand<CreatePetCommand>,
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
            
            var profile = await profileRepository.FindByUser(currentUser.UserId);

            if (profile.Id != request.ProfileId)
                return "You cannot create a pet for this user";
            
            if (profile == null)
                return "There is no Profile with this id";

            if (request.Years == 0 && request.Months == 0)
                return "Please enter a valid age";
            
            var pet = petFactory
                .WithName(request.Name)
                .WithPhotoUrl(request.PhotoUrl)
                .WithType(request.PetType)
                .WithAge(request.Years, request.Months)
                .WithGender(request.Gender)
                .WithBreed(request.Breed)
                .WithWeight(request.Weight)
                .WithPersonality(
                    request.Temperament,
                    request.ActivityLevel,
                    request.IsTrained,
                    request.HasFears,
                    request.FearsDescription)
                .WithHealthStatus(
                    request.IsVaccinated,
                    request.IsCastrated,
                    request.TakesMedications,
                    request.HasEatingSchedule,
                    request.OtherDietaryNeeds,
                    request.HealthProblems)
                .WithProfileId(profile.Id)
                .Build();

            await petRepository.Save(pet, cancellationToken);

            return new CreatePetOutputModel(pet.Id);
        }
    }
}