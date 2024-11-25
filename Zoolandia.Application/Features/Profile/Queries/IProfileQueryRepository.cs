namespace Zoolandia.Application.Features.Profile.Queries;

public interface IProfileQueryRepository
{
    Task<ProfileDetailsOutputModel> UserDetails(string userId, CancellationToken cancellationToken);
}