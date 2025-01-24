using Zoolandia.Application.Common.Mapping;

namespace Zoolandia.Application.Features.Post.Queries.Search;

public class PostOutputModel : IMapFrom<Domain.Models.Post>
{
    public string Id { get; set; }
    public string FirstName { get; set; }
    
    public string LastName { get; set; }
    
    public string PhotoUrl { get; set; }
    
    public string Description { get; set; }
    
    public int ServicePrice { get; set; }
    
}