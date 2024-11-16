using Microsoft.AspNetCore.Identity;
using Zoolandia.Application.Identity;
using Zoolandia.Domain.Models;

namespace Zoolandia.Infrastructure.Identity;

public class User : IdentityUser
{
    public Profile Profile { get; set; }
}