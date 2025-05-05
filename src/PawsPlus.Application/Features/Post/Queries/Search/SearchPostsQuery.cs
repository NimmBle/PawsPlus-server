using MediatR;
using PawsPlus.Application.Common;

namespace PawsPlus.Application.Features.Post.Queries.Search;

public class SearchPostsQuery 
    : SearchPostsParams,
        IRequest<Result<SearchPostsOutputModel>> 
{
    public class SearchPostQueryHandler(IPostQueryRepository postRepository) 
        : IRequestHandler<SearchPostsQuery, Result<SearchPostsOutputModel>>
    {
        public async Task<Result<SearchPostsOutputModel>> Handle(SearchPostsQuery request,
            CancellationToken cancellationToken)
        {
            var predicate = request.ToPredicate();
            var orderBy = request.OrderBy();
            int skip = (request.Page - 1) * request.PostsPerPage;
            int take = request.PostsPerPage;
            
            var posts = await postRepository.Search(predicate,
                orderBy,
                request.ServiceType,
                skip,
                take,
                request.OrderType,
                cancellationToken);

            if (posts == null)
            {
                return new SearchPostsOutputModel();
            }
            
            int totalPages = (int)Math.Ceiling(posts.Count() / request.PostsPerPage * 1.0);
            
            return new SearchPostsOutputModel(posts,
                totalPages,
                request.Page
                );
        }
    }
}