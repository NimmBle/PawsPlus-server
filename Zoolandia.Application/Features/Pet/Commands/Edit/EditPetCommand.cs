using MediatR;
using Zoolandia.Application.Common;
using Zoolandia.Domain.Repositories;

namespace Zoolandia.Application.Features.Pet.Commands.Edit;

public class EditPetCommand 
    : EditPetInputModel,
        IRequest<Result>
{
    public string? Id { get; set; }
    
    public class EditPetCommandHandler
        (IPetDomainRepository petDomainRepository, 
            IPetQueryRepository petQueryRepository)
        : IRequestHandler<EditPetCommand, Result>
    {
        public async Task<Result> Handle(EditPetCommand request, CancellationToken cancellationToken)
        {
            var pet = await petQueryRepository.FindPetById(request.Id);

            if (pet == null)
                return false;

            pet.Name = request.Name;
            pet.PhotoUrl = request.PhotoUrl;
            pet.PetType = request.PetType;
            pet.Age = Domain.ValueObjects.Age.Create(
                request.Age.Years,
                request.Age.Months);
            pet.Gender = request.Gender;
            pet.Breed = request.Breed;
            pet.Weight = request.Weight;
            pet.Personality = Domain.ValueObjects.Personality.Create(
                request.Personality.Temperament,
                request.Personality.ActivityLevel,
                request.Personality.IsTrained,
                request.Personality.HasFears,
                request.Personality.FearsDescription);
            pet.HealthStatus = Domain.ValueObjects.HealthStatus.Create(
                request.HealthStatus.IsVaccinated,
                request.HealthStatus.IsCastrated,
                request.HealthStatus.TakesMedications,
                request.HealthStatus.HasEatingSchedule,
                request.HealthStatus.OtherDietaryNeeds,
                request.HealthStatus.HealthProblems);

            await petDomainRepository.Update(pet, cancellationToken);
            
            return true;

        }
    }
}