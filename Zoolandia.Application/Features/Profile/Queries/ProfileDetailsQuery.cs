using MediatR;
using Zoolandia.Application.Common;
using Zoolandia.Application.Common.Contracts;
using Zoolandia.Application.Features.Profil;
using Zoolandia.Domain.Repositories;

namespace Zoolandia.Application.Features.Profile.Queries;

public class ProfileDetailsQuery : IRequest<Result<ProfileDetailsOutputModel>>
{
    public string? Id { get; set; }
    
    public class ProfileDetailsQueryHandler(
        ICurrentUser currentUser,
        IProfileDomainRepository profileDomainRepository,
        IProfileQueryRepository profileQueryRepository)
        : IRequestHandler<ProfileDetailsQuery,
        Result<ProfileDetailsOutputModel>>
    {
        public async Task<Result<ProfileDetailsOutputModel>> Handle(
            ProfileDetailsQuery request,
            CancellationToken cancellationToken)
        {
            var profileId = await profileDomainRepository.GetProfileId(request.Id);

            if (profileId == null)
            {
                var currentUserId = currentUser.UserId;
                
                profileId = await profileDomainRepository.GetProfileId(currentUserId);
            }
            
            var profileData = await profileQueryRepository.GetDetails(profileId);

            profileData.Email = await profileQueryRepository.GetEmail(currentUser.UserId);

            return profileData;
        }
    }
}