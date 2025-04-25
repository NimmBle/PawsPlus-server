using PawsPlus.Application.Common.Contracts;

namespace Application.IntegrationTests;

public class CurrentUserMock : ICurrentUser
{
    public CurrentUserMock(string userId)
    {
        UserId = userId;
    }

    public string UserId { get; }
    public string UserName { get; }
}