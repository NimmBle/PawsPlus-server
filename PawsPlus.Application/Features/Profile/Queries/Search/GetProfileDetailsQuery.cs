using MediatR;
using PawsPlus.Application.Common;
using PawsPlus.Application.Features.Post;

namespace PawsPlus.Application.Features.Profile.Queries.Search;

public class GetProfileDetailsQuery : IRequest<Result<ProfileDetailsOutputModel>>
{
    public string? Id { get; set; }
    
    public class GetProfileDetailsQueryHandler(IProfileQueryRepository profileQueryRepository,
        IPostQueryRepository postQueryRepository)
        : IRequestHandler<GetProfileDetailsQuery, Result<ProfileDetailsOutputModel>>
    {
        public async Task<Result<ProfileDetailsOutputModel>> Handle(
            GetProfileDetailsQuery request,
            CancellationToken cancellationToken)
        {
            var profile = await profileQueryRepository.GetDetails(request.Id);
            
            if (profile == null)
                return Result<ProfileDetailsOutputModel>.Failure("Profile not found");
            
            profile.Post = await postQueryRepository.GetDetailsByProfile(request.Id);
            
            return profile; 
        }
    }
}