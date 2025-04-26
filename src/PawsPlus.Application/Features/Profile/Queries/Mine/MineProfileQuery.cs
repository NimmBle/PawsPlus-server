using MediatR;
using PawsPlus.Application.Common;
using PawsPlus.Application.Common.Contracts;
using PawsPlus.Application.Features.Reviews;
using PawsPlus.Application.Identity;

namespace PawsPlus.Application.Features.Profile.Queries.Mine;

public class MineProfileQuery : IRequest<Result<MineProfileOutputModel>>
{
    public class MineProfileQueryHandler(ICurrentUser currentUser,
        IIdentity identity,
        IProfileQueryRepository profileQueryRepository,
        IReviewQueryRepository reviewQueryRepository) 
        : IRequestHandler<MineProfileQuery, Result<MineProfileOutputModel>>
    {
        public async Task<Result<MineProfileOutputModel>> Handle(MineProfileQuery request,
            CancellationToken cancellationToken)
        {
            var profileId = await profileQueryRepository.GetProfileIdByUser(currentUser.UserId);
            
            var profile = await profileQueryRepository.GetMine(profileId); 
            
            profile.Email = await identity.GetEmail(currentUser.UserId);
            profile.Roles = await identity.GetRoles(currentUser.UserId);
            profile.Reviews = await reviewQueryRepository.GetByReviewedId(profile.Id);
            
            return profile;
        } 
    }
}