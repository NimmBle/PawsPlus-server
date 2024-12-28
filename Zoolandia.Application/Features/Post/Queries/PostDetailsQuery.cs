using MediatR;
using Zoolandia.Application.Common;
using Zoolandia.Application.Common.Contracts;

namespace Zoolandia.Application.Features.Post.Queries;

public class PostDetailsQuery : IRequest<Result<PostDetailsOutputModel>>
{
    public string? Id { get; set; }
    
    public class PostDetailsQueryHandler(
        ICurrentUser currentUser,
        IPostQueryRepository postQueryRepository)
        : IRequestHandler<PostDetailsQuery,
            Result<PostDetailsOutputModel>>
    {
        public async Task<Result<PostDetailsOutputModel>> Handle(
            PostDetailsQuery request,
            CancellationToken cancellationToken)
        {
            return await postQueryRepository.PostDetails(request.Id);
        }
    }
}