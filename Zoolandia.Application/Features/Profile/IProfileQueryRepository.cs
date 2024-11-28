using Zoolandia.Application.Features.Profile.Queries;

namespace Zoolandia.Application.Features.Profil;

public interface IProfileQueryRepository
{
    Task<ProfileDetailsOutputModel> GetDetails(string profileId, CancellationToken cancellationToken = default);

    Task<string> GetEmail(string userId, CancellationToken cancellationToken = default);
}