using MediatR;
using PawsPlus.Application.Common;

namespace PawsPlus.Application.Features.Post.Queries;

public class GetPostDetailsQuery : IRequest<Result<PostDetailsOutputModel>>
{
    public string Id { get; set; }
    
    public class PostDetailsQueryHandler(
        IPostQueryRepository postQueryRepository)
        : IRequestHandler<GetPostDetailsQuery, Result<PostDetailsOutputModel>>
    {
        public async Task<Result<PostDetailsOutputModel>> Handle(
            GetPostDetailsQuery request,
            CancellationToken cancellationToken)
        {
            return await postQueryRepository.GetDetails(request.Id);
        }
    }
}