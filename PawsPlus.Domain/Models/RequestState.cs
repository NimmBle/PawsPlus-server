using PawsPlus.Domain.Common.Models;

namespace PawsPlus.Domain.Models;

public class RequestState : Enumeration
{
    public static readonly RequestState Pending = new RequestState(1, nameof(Pending));
    public static readonly RequestState Canceled = new RequestState(2, nameof(Canceled));
    public static readonly RequestState Disapproved = new RequestState(3, nameof(Disapproved));
    public static readonly RequestState Approved = new RequestState(4, nameof(Approved));
    
    
    private RequestState(int value)
        : base(value, FromValue<RequestState>(value).Name)
    {
    }


    public RequestState(int value, string name)
        : base(value, name)
    {
    }
}