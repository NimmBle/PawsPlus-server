using MediatR;
using Zoolandia.Application.Common;

namespace Zoolandia.Application.Features.Post.Queries;

public class GetProfilePostDetailsQuery : IRequest<Result<PostDetailsOutputModel>>
{
    public string Id { get; set; }
    
    public class GetProfilePostDetailsQueryHandler(
        IPostQueryRepository postQueryRepository)
        : IRequestHandler<GetProfilePostDetailsQuery, Result<PostDetailsOutputModel>>
    {
        public async Task<Result<PostDetailsOutputModel>> Handle(
            GetProfilePostDetailsQuery request,
            CancellationToken cancellationToken)
        {
            return await postQueryRepository.GetPostDetailsByProfile(request.Id);
        }
        
    }
}