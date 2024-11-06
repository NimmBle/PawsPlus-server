using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Zoolandia.Server.Data.Models;

namespace Zoolandia.Server.Data;

public class ZoolandiaDbContext : IdentityDbContext
{
    public ZoolandiaDbContext(DbContextOptions<ZoolandiaDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<User>()
            .OwnsOne(u => u.Profile);
        
        base.OnModelCreating(builder);
    }
}