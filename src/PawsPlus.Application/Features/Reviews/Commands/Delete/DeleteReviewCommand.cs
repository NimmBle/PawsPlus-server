using MediatR;
using PawsPlus.Application.Common;
using PawsPlus.Domain.Repositories;

namespace PawsPlus.Application.Features.Reviews.Commands.Delete;

public class DeleteReviewCommand : IRequest<Result>
{
    public string Id { get; set; }
    
    public class DeleteReviewCommandHandler(IReviewDomainRepository reviewDomainRepository)
        : IRequestHandler<DeleteReviewCommand, Result>
    {
        public async Task<Result> Handle(DeleteReviewCommand request,
            CancellationToken cancellationToken)
            => await reviewDomainRepository.Delete(request.Id);
    }
}