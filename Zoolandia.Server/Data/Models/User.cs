using Microsoft.AspNetCore.Identity;

namespace Zoolandia.Server.Data.Models;

public class User : IdentityUser
{
    public Profile Profile { get; set; }
}