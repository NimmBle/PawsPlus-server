using MediatR;
using PawsPlus.Application.Common;
using PawsPlus.Domain.Repositories;

namespace PawsPlus.Application.Features.Pet.Commands.Delete;

public class DeletePetCommand : EntityCommand<string>, IRequest<Result>
{
    class DeletePetCommandHandler(IPetDomainRepository petDomainRepository)
        : IRequestHandler<DeletePetCommand, Result>
    {
        public async Task<Result> Handle(DeletePetCommand request,
            CancellationToken cancellationToken)
            => await petDomainRepository.Delete(request.Id);
    }
}