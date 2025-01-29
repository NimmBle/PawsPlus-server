using System.Linq.Expressions;
using Zoolandia.Application.Features.Post.Queries;
using Zoolandia.Application.Features.Post.Queries.Search;
using Zoolandia.Domain.Enums;

namespace Zoolandia.Application.Features.Post;

public interface IPostQueryRepository
{ 
    Task<PostDetailsOutputModel> GetDetails(string profileId, CancellationToken cancellationToken = default);

    Task<PostDetailsOutputModel> GetDetailsByProfile(string profileId, CancellationToken cancellationToken = default);

    Task<IReadOnlyCollection<PostOutputModel>> Search(Expression<Func<Domain.Models.Post, bool>> predicate,
        ServiceType serviceType,
        int skip,
        int take,
        CancellationToken cancellationToken = default);
}