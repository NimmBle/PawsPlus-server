using MediatR;
using PawsPlus.Application.Common;
using PawsPlus.Domain.Errors;
using PawsPlus.Domain.Repositories;

namespace PawsPlus.Application.Features.Post.Commands.Activate;

public class ActivatePostCommand : IRequest<Result>
{
    public string Id { get; set; }
    
    public class ActivateProfileCommandHandler(IPostDomainRepository postDomainRepository)
        : IRequestHandler<ActivatePostCommand, Result>
    {
        public async Task<Result> Handle(ActivatePostCommand request, CancellationToken cancellationToken)
        {
            var post = await postDomainRepository.FindByProfile(request.Id);

            if (post == null)
            {
                return PostErrors.PostNotFound("");
            }

            post.ChangeState("Pending");
            
            await postDomainRepository.Update(post);
            
            return Result.Success;
        }
    }
}