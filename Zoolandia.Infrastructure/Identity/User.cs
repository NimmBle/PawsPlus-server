using Microsoft.AspNetCore.Identity;
using Zoolandia.Application.Identity;
using Zoolandia.Domain.Models;

namespace Zoolandia.Infrastructure.Identity;

public class User : IdentityUser, IUser
{
    internal User()
    {
    }

    internal User(
        string email,
        string userName)
        : base(userName)
    {
        this.Email = email;
    }
    public Profile? Profile { get; private set; }

    public void CreateProfile(Profile profile)
    {
        if (Profile != null)
            throw new Exception(); // Add DomainExceptions
        
        Profile = profile;
    }
    
}