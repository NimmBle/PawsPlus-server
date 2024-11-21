namespace Zoolandia.Application.Common.Contracts;

public interface ICurrentUser
{ 
    public string UserId { get; }

    public string UserName { get; }
}