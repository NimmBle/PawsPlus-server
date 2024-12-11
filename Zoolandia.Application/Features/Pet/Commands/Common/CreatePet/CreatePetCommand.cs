using MediatR;
using Zoolandia.Application.Common;
using Zoolandia.Application.Features.Pet.Commands.Common;
using Zoolandia.Domain.Repositories;

namespace Zoolandia.Application.Features.Pet.Commands.CreatePet;

public class CreatePetCommand :  PetCommand<CreatePetCommand>, IRequest<Result>
{
    public class CreatePetCommandHandler(IPetDomainRepository petRepository): IRequestHandler<CreatePetCommand, Result>
    {
        public async Task<Result> Handle(CreatePetCommand request, CancellationToken cancellationToken)
        {
            return "baban";
        }
    }
}