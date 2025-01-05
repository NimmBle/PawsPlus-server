using MediatR;
using Zoolandia.Application.Common;
using Zoolandia.Application.Common.Contracts;
using Zoolandia.Application.Identity;

namespace Zoolandia.Application.Features.Profile.Queries;

public class ProfileDetailsQuery : IRequest<Result<ProfileDetailsOutputModel>>
{
    public string? Id { get; set; }
    
    public class ProfileDetailsQueryHandler(
        ICurrentUser currentUser,
        IIdentity identity,
        IProfileQueryRepository profileQueryRepository)
        : IRequestHandler<ProfileDetailsQuery,
            Result<ProfileDetailsOutputModel>>
    {
        public async Task<Result<ProfileDetailsOutputModel>> Handle(
            ProfileDetailsQuery request,
            CancellationToken cancellationToken)
        {
            var currentUserId = currentUser.UserId;

            var profile = await profileQueryRepository.GetDetailsByUser(currentUserId);
            
            var roles = await identity.GetRoles(currentUserId);
            
            profile.Roles = roles;

            return profile;
        }
    }
}