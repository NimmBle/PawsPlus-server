using PawsPlus.Application.Features.Profile.Queries.Mine;
using PawsPlus.Application.Features.Profile.Queries.Search;

namespace PawsPlus.Application.Features.Profile;

public interface IProfileQueryRepository
{
    Task<ProfileDetailsOutputModel> GetDetails(string profileId, CancellationToken cancellationToken = default);
    
    Task<MineProfileOutputModel> GetDetailsByUser(string userId, CancellationToken cancellationToken = default);
    
}