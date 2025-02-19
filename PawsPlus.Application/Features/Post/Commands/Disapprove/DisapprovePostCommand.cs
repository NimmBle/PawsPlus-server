using MediatR;
using PawsPlus.Application.Common;
using PawsPlus.Domain.Errors;
using PawsPlus.Domain.Models;
using PawsPlus.Domain.Repositories;
using PawsPlus.Domain.Services;

namespace PawsPlus.Application.Features.Post.Commands.Disapprove;

public class DisapprovePostCommand : IRequest<Result>
{
    public string Id { get; init; }
    
    public string StateReason { get; init; }
    
    public class DisapprovePostCommandHandler(IPostDomainRepository postDomainRepository,
        IEmailSender emailSender)
        : IRequestHandler<DisapprovePostCommand, Result>
    {
        public async Task<Result> Handle(DisapprovePostCommand request, CancellationToken cancellationToken)
        {
            var post = await postDomainRepository.Find(request.Id);

            if (post == null)
            {
                return PostErrors.PostNotFound(request.Id);
            }

            if (post.IsAlreadyResolved())
            {
                return PostErrors.PostAlreadyResolved;
            }

            post.ChangeState("Disapproved");

            await postDomainRepository.Update(post);

            await emailSender.SendPostDisapproveEmail(post.ProfileId, request.StateReason);
            
            return Result.Success;
        }
    }
}