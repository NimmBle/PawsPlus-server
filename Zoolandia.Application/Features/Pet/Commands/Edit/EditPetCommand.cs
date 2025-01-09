using AutoMapper;
using MediatR;
using Zoolandia.Application.Common;
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
            IPetQueryRepository petQueryRepository,
            IMapper mapper)
        : IRequestHandler<EditPetCommand, Result>
    {
        public async Task<Result> Handle(EditPetCommand request, CancellationToken cancellationToken)
        {
            var pet = await petQueryRepository.FindPetById(request.Id);

            if (pet == null)
                return false;

            pet.Update(
                request.Name,
                request.PhotoUrl,
                request.PetType,
                mapper.Map<Age>(request.Age),
                request.Gender,
                request.Breed,
                request.Weight,
                mapper.Map<Personality>(request.Personality),
                mapper.Map<HealthStatus>(request.HealthStatus));

            await petDomainRepository.Update(pet, cancellationToken);
            
            return true;

        }
    }
}