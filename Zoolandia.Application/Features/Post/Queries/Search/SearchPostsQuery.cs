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
            
            var posts = await  postRepository.SearchPosts(predicate, request.ServiceType, cancellationToken);

            if (posts is null)
                return Result<SearchPostsOutputModel>.Failure("No posts found");
            
            int totalPages = posts.Count() / request.PostsPerPage;
            
            return new SearchPostsOutputModel(
                posts,
                totalPages,
                request.PostsPerPage
                );
        }
    }
}