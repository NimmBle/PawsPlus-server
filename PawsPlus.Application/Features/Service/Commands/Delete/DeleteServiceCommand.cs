using MediatR;
using PawsPlus.Application.Common;
using PawsPlus.Domain.Repositories;

namespace PawsPlus.Application.Features.Service.Commands.Delete;

public class DeleteServiceCommand : IRequest<Result>
{
    public string Id { get; set; }

    public class DeleteServiceCommandHandler(IServiceDomainRepository serviceDomainRepository)
        : IRequestHandler<DeleteServiceCommand, Result>
    {
        public async Task<Result> Handle(DeleteServiceCommand request,
            CancellationToken cancellationToken)
            => await serviceDomainRepository.Delete(request.Id, cancellationToken);
    }
}