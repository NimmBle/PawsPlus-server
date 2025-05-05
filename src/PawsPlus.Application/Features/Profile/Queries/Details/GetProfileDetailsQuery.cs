using MediatR;
using PawsPlus.Application.Common;
using PawsPlus.Application.Features.Post;
using PawsPlus.Application.Features.Reviews;
using PawsPlus.Domain.Errors;

namespace PawsPlus.Application.Features.Profile.Queries.Details;

public class GetProfileDetailsQuery : IRequest<Result<ProfileDetailsOutputModel>>
{
    public string? Id { get; set; }
    
    public class GetProfileDetailsQueryHandler(IProfileQueryRepository profileQueryRepository,
        IPostQueryRepository postQueryRepository,
        IReviewQueryRepository reviewQueryRepository)
        : IRequestHandler<GetProfileDetailsQuery, Result<ProfileDetailsOutputModel>>
    {
        public async Task<Result<ProfileDetailsOutputModel>> Handle(GetProfileDetailsQuery request,
            CancellationToken cancellationToken)
        {
            var profile = await profileQueryRepository.GetDetails(request.Id, cancellationToken);

            if (profile == null)
            {
                return ProfileErrors.ProfileNotFound(request.Id);
            }
            
            profile.Post = await postQueryRepository.GetDetailsByProfile(request.Id, cancellationToken);
             
            profile.Reviews = await reviewQueryRepository.GetByReviewedId(request.Id, cancellationToken);
            
            return profile; 
        }
    }
}