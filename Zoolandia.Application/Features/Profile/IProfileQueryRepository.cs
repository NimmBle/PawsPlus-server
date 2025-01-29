using Zoolandia.Application.Features.Profile.Queries.Mine;
using Zoolandia.Application.Features.Profile.Queries.Search;

namespace Zoolandia.Application.Features.Profile;

public interface IProfileQueryRepository
{
    Task<ProfileDetailsOutputModel> GetDetails(string profileId, CancellationToken cancellationToken = default);
    
    Task<MineProfileOutputModel> GetDetailsByUser(string userId, CancellationToken cancellationToken = default);
    
}