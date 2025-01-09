using MediatR;
using Zoolandia.Application.Common;
using Zoolandia.Application.Common.Contracts;

namespace Zoolandia.Application.Features.Post.Queries;

public class GetPostDetailsQuery : IRequest<Result<PostDetailsOutputModel>>
{
    public string Id { get; set; }
    
    public class PostDetailsQueryHandler(
        ICurrentUser currentUser,
        IPostQueryRepository postQueryRepository)
        : IRequestHandler<GetPostDetailsQuery,
            Result<PostDetailsOutputModel>>
    {
        public async Task<Result<PostDetailsOutputModel>> Handle(
            GetPostDetailsQuery request,
            CancellationToken cancellationToken)
        {
            return await postQueryRepository.PostDetails(request.Id);
        }
    }
}