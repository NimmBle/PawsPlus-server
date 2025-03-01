namespace PawsPlus.Application.Features.Post.Queries.Search;

public class SearchPostsOutputModel
{
    internal SearchPostsOutputModel()
    {
    }
    
    internal SearchPostsOutputModel(IReadOnlyCollection<PostOutputModel> posts,
        int totalPages,
        int page = 1)
    {
        Posts = posts;
        TotalPages = totalPages;
        Page = page;
    }
    
    public IReadOnlyCollection<PostOutputModel> Posts { get; set; }
    
    public int? Page { get; set; }
    
    public int? TotalPages { get; set; }
}