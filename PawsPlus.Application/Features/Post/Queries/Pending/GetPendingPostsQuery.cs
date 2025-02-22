using MediatR;

namespace PawsPlus.Application.Features.Post.Queries.Pending;

public class GetPendingPostsQuery : IRequest<ICollection<PendingPostOutputModel>>
{
    public int PostsPerPage { get; set; } = 10;
    
    public int Page { get; set; } = 1;
    
    public class GetPendingPostsQueryHandler(IPostQueryRepository postQueryRepository) 
        : IRequestHandler<GetPendingPostsQuery, ICollection<PendingPostOutputModel>>
    {
        public async Task<ICollection<PendingPostOutputModel>> Handle(GetPendingPostsQuery request, CancellationToken cancellationToken)
        {
            var skip = (request.Page - 1) * request.PostsPerPage;
            
            var posts = await postQueryRepository.GetPending(skip, request.PostsPerPage);

            if (posts == null)
            {
                return new List<PendingPostOutputModel>();
            }
            
            return posts;
        }
    }
}