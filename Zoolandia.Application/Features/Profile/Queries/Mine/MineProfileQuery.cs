using MediatR;
using Zoolandia.Application.Common;
using Zoolandia.Application.Common.Contracts;
using Zoolandia.Application.Identity;

namespace Zoolandia.Application.Features.Profile.Queries.Mine;

public class MineProfileQuery : IRequest<Result<MineProfileOutputModel>>
{
    public class MineProfileQueryHandler(
        ICurrentUser currentUser,
        IIdentity identity,
        IProfileQueryRepository profileQueryRepository) 
        : IRequestHandler<MineProfileQuery, Result<MineProfileOutputModel>>
    {
        public async Task<Result<MineProfileOutputModel>> Handle(
            MineProfileQuery request,
            CancellationToken cancellationToken)
        {
            var profile = await profileQueryRepository.GetMineProfileByUser(currentUser.UserId);
            profile.Roles = await identity.GetRoles(currentUser.UserId);

            return profile;
        } 
    }
}