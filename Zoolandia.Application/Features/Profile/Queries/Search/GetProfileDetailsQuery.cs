using MediatR;
using Zoolandia.Application.Common;
using Zoolandia.Application.Features.Post;

namespace Zoolandia.Application.Features.Profile.Queries.Search;

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
            profile.Post = await postQueryRepository.GetPostDetailsByProfile(request.Id);
            
            return profile; 
        }
    }
}