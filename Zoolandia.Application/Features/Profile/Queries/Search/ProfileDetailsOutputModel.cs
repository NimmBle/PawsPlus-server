using Zoolandia.Application.Features.Post.Queries;

namespace Zoolandia.Application.Features.Profile.Queries.Search;

public class ProfileDetailsOutputModel : ProfileOutputModel
{
    public PostDetailsOutputModel? Post { get; set; }

}