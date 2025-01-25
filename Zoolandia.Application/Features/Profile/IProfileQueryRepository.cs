using Zoolandia.Application.Features.Profile.Queries.Mine;
using Zoolandia.Application.Features.Profile.Queries.Search;

namespace Zoolandia.Application.Features.Profile;

public interface IProfileQueryRepository
{
    Task<ProfileDetailsOutputModel> GetDetails(string profileId, CancellationToken cancellationToken = default);
    
    Task<MineProfileOutputModel> GetMineProfileByUser(string userId, CancellationToken cancellationToken = default);

    Task<string> GetEmailByUser(string userId, CancellationToken cancellationToken = default);
}