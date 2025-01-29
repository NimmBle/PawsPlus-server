using System.Reflection.Metadata.Ecma335;
using MediatR;
using Zoolandia.Application.Common;

namespace Zoolandia.Application.Features.Post.Queries.Search;

public class SearchPostsQuery : SearchPostsParams, IRequest<Result<SearchPostsOutputModel>> 
{
    public class SearchPostQueryHandler
        (IPostQueryRepository postRepository) 
        : IRequestHandler<SearchPostsQuery, Result<SearchPostsOutputModel>>
    {
        public async Task<Result<SearchPostsOutputModel>> Handle(
            SearchPostsQuery request,
            CancellationToken cancellationToken)
        {
            var predicate = request.ToPredicate();
            int skip = (request.Page - 1) * request.PostsPerPage;
            int take = request.PostsPerPage;
            
            var posts = await postRepository.Search(predicate,
                request.ServiceType,
                skip,
                take,
                cancellationToken);

            if (posts is null)
                return Result<SearchPostsOutputModel>.Failure("No posts found");
            
            int totalPages = (int)Math.Ceiling(posts.Count() / request.PostsPerPage * 1.0);
            
            return new SearchPostsOutputModel(
                posts,
                totalPages,
                request.Page
                );
        }
    }
}