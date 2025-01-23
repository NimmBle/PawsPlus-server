using Zoolandia.Domain.Common.Models;

namespace Zoolandia.Domain.Models;

public class StateType : Enumeration
{
    public static readonly StateType None = new StateType(1, nameof(None));
    public static readonly StateType Pending = new StateType(2, nameof(Pending));
    public static readonly StateType Disapproved = new StateType(3, nameof(Disapproved));
    public static readonly StateType Approved = new StateType(4, nameof(Approved));
    
    
    private StateType(int value)
        : base(value, FromValue<StateType>(value).Name)
    {
    }


    public StateType(int value, string name)
        : base(value, name)
    {
    }
}