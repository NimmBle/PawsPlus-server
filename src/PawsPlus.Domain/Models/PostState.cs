using PawsPlus.Domain.Common.Models;

namespace PawsPlus.Domain.Models;

public class PostState : Enumeration
{
    public static readonly PostState None = new PostState(1, nameof(None));
    public static readonly PostState Pending = new PostState(2, nameof(Pending));
    public static readonly PostState Disapproved = new PostState(3, nameof(Disapproved));
    public static readonly PostState Approved = new PostState(4, nameof(Approved));
    
    
    private PostState(int value)
        : base(value, FromValue<PostState>(value).Name)
    {
    }


    public PostState(int value,
        string name)
        : base(value, name)
    {
    }
}