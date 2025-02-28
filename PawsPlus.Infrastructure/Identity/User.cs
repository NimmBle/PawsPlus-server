using Microsoft.AspNetCore.Identity;
using PawsPlus.Application.Identity;
using PawsPlus.Domain.Models;

namespace PawsPlus.Infrastructure.Identity;

public class User : IdentityUser, IUser
{
    internal User()
    {
    }

    internal User(string email,
        string userName)
        : base(userName)
    {
        this.Email = email;
    }
    
    public Profile? Profile { get; private set; }

    public void CreateProfile(Profile profile)
    {
        if (Profile != null)
        {
            throw new Exception();
        }
        
        this.Profile = profile;
    }
    
}