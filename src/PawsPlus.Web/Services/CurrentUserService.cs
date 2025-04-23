using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using PawsPlus.Application.Common.Contracts;

namespace PawsPlus.Web.Services;

public class CurrentUserService : ICurrentUser
{
    public CurrentUserService(IHttpContextAccessor httpContextAccessor)
    {
        var user = httpContextAccessor.HttpContext?.User;

        if (user == null)
        {
            throw new InvalidOperationException("This request does not have an authenticated user");
        }

        this.UserId = user.FindFirstValue(ClaimTypes.NameIdentifier);
        this.UserName = user.FindFirstValue(ClaimTypes.Name);
    }
    
    public string UserId { get; }

    public string UserName { get; }
}