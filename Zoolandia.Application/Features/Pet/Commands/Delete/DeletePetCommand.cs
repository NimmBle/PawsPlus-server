using MediatR;
using Zoolandia.Application.Common;
using Zoolandia.Domain.Repositories;

namespace Zoolandia.Application.Features.Pet.Commands.Delete;

public class DeletePetCommand : EntityCommand<string>, IRequest<Result>
{
    class DeletePetCommandHandler(IPetDomainRepository petDomainRepository)
        : IRequestHandler<DeletePetCommand, Result>
    {
        public async Task<Result> Handle(
            DeletePetCommand request,
            CancellationToken cancellationToken)
            => await petDomainRepository.Delete(request.Id);
    }
}