using PawsPlus.Application.Features.Post.Queries;

namespace PawsPlus.Application.Features.Profile.Queries.Search;

public class ProfileDetailsOutputModel : ProfileOutputModel
{
    public PostDetailsOutputModel? Post { get; set; }

}