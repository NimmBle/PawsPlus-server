using System.Linq.Expressions;
using PawsPlus.Application.Features.Post.Queries;
using PawsPlus.Application.Features.Post.Queries.Search;
using PawsPlus.Domain.Enums;

namespace PawsPlus.Application.Features.Post;

public interface IPostQueryRepository
{ 
    Task<PostDetailsOutputModel> GetDetails(string profileId, CancellationToken cancellationToken = default);

    Task<PostDetailsOutputModel> GetDetailsByProfile(string profileId, CancellationToken cancellationToken = default);

    Task<IReadOnlyCollection<PostOutputModel>> Search(Expression<Func<Domain.Models.Post, bool>> predicate,
        Expression<Func<Domain.Models.Post, object>> orderBy,
        ServiceType serviceType,
        int skip,
        int take,
        CancellationToken cancellationToken = default);
}