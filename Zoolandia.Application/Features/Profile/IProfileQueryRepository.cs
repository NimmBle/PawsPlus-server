using Zoolandia.Application.Features.Profile.Queries;

namespace Zoolandia.Application.Features.Profile;

public interface IProfileQueryRepository
{
    Task<ProfileDetailsOutputModel> GetDetails(string profileId, CancellationToken cancellationToken = default);
    
    Task<ProfileDetailsOutputModel> GetDetailsByUser(string userId, CancellationToken cancellationToken = default);

    Task<string> GetEmail(string userId, CancellationToken cancellationToken = default);
}