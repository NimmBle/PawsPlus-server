using System.Reflection;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Zoolandia.Domain.Models;
using Zoolandia.Infrastructure.Identity;

namespace Zoolandia.Infrastructure.Common.Persistence;

public class 
    ZoolandiaDbContext(DbContextOptions<ZoolandiaDbContext> options)
        : IdentityDbContext<User>(options)
{
    public DbSet<Profile> Profiles { get; set; } = default!;

    public DbSet<Pet> Pets { get; set; } = default!;

    public DbSet<JobPost> JobPosts { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(typeof(ZoolandiaDbContext).Assembly);
        
        base.OnModelCreating(builder);
    }
}