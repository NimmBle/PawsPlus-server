using Zoolandia.Application.Features.Post.Queries;

namespace Zoolandia.Application.Features.Post;

public interface IPostQueryRepository
{ 
    Task<PostDetailsOutputModel> GetPostDetails(string profileId);

    Task<PostDetailsOutputModel> GetPostDetailsByProfile(string profileId);
}