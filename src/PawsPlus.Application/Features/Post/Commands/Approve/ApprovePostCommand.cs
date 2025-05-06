using MediatR;
using PawsPlus.Application.Common;
using PawsPlus.Domain.Errors;
using PawsPlus.Domain.Repositories;
using PawsPlus.Domain.Services;

namespace PawsPlus.Application.Features.Post.Commands.Approve;

public class ApprovePostCommand : IRequest<Result>
{
    public string Id { get; init; }
    
    public class ApprovePostCommandHandler(IPostDomainRepository postDomainRepository,
        IEmailSender emailSender) 
        : IRequestHandler<ApprovePostCommand, Result>
    {
        public async Task<Result> Handle(ApprovePostCommand request,
            CancellationToken cancellationToken)
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

            post.ChangeState("Approved");
            
            await postDomainRepository.Update(post);

            await emailSender.SendPostApproveEmail(post.ProfileId);
            
            return Result.Success;
        }
    }
}