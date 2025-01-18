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

    public DbSet<Post> Posts { get; set; } = default!;
    
    public DbSet<Service> Services { get; set; } = default!;

    public DbSet<Meeting> Meetings { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder
            .Entity<Meeting>()
            .HasOne(p => p.Profile)
            .WithOne(p => p.Meeting)
            .HasForeignKey<Meeting>("SitterId");
        
        builder.ApplyConfigurationsFromAssembly(typeof(ZoolandiaDbContext).Assembly);
        
        base.OnModelCreating(builder);
    }
}