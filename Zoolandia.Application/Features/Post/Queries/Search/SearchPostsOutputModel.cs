namespace Zoolandia.Application.Features.Post.Queries.Search;

public class SearchPostsOutputModel
{
    public SearchPostsOutputModel(ICollection<PostOutputModel> posts, int totalPages, int page = 1)
    {
        Posts = posts;
        TotalPages = totalPages;
        Page = page;
    }
    
    public ICollection<PostOutputModel> Posts { get; set; } = new List<PostOutputModel>();
    
    public int? Page { get; set; }
    
    public int? TotalPages { get; set; }
}