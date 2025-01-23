using System.Linq.Expressions;
using Zoolandia.Application.Features.Post.Queries;
using Zoolandia.Application.Features.Post.Queries.Search;
using Zoolandia.Domain.Enums;

namespace Zoolandia.Application.Features.Post;

public interface IPostQueryRepository
{ 
    Task<PostDetailsOutputModel> GetPostDetails(string profileId, CancellationToken cancellationToken = default);

    Task<PostDetailsOutputModel> GetPostDetailsByProfile(string profileId, CancellationToken cancellationToken = default);

    Task<ICollection<PostOutputModel>> SearchPosts(Expression<Func<Domain.Models.Post, bool>> predicate, ServiceType serviceType, CancellationToken cancellationToken = default);
}