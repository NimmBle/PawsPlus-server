using Zoolandia.Domain.Enums.Pet;

namespace Zoolandia.Application.Features.Post.Commands;

public class PostInputModel
{
    public HashSet<Weight>? Weights { get; set; }
    
}