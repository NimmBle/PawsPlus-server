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
            var profileId = await profileQueryRepository.GetProfileIdByUser(currentUser.UserId);
            
            var profile = await profileQueryRepository.GetMine(profileId);

            if (profile == null)
            {
                var adminProfile = new MineProfileOutputModel();
                
                var roles = await identity.GetRoles(currentUser.UserId);
                
                if (roles.Count > 0 && roles.Contains("Administrator"))
                {
                    adminProfile.Roles = roles;
                    return adminProfile;
                }
            }
            
            profile.Email = await identity.GetEmail(currentUser.UserId);
            profile.Roles = await identity.GetRoles(currentUser.UserId);
            
            return profile;
        } 
    }
}