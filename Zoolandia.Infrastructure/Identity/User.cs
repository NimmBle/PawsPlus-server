using Microsoft.AspNetCore.Identity;
using Zoolandia.Infrastructure.Data.Models;

namespace Zoolandia.Infrastructure.Identity;

public class User : IdentityUser
{
    public Profile Profile { get; set; }
}