using MediatR;
using PawsPlus.Application.Common;
using PawsPlus.Application.Common.Contracts;
using PawsPlus.Application.Identity;

namespace PawsPlus.Application.Features.Profile.Queries.Mine;

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
            var profile = await profileQueryRepository.GetDetailsByUser(currentUser.UserId);
            profile.Roles = await identity.GetRoles(currentUser.UserId);

            return profile;
        } 
    }
}