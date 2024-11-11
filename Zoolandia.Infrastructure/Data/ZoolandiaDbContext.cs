using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Zoolandia.Infrastructure.Identity;

namespace Zoolandia.Infrastructure.Data;

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
        
        string[] roleNames = { "Administrator", "Owner", "Sitter" };
        string roleId = default!;
        foreach (var role in roleNames)
        {
            roleId = Guid.NewGuid().ToString();
            builder.Entity<IdentityRole>()
                .HasData(new IdentityRole
                {
                    Id = roleId,
                    Name = role,
                    NormalizedName = role.ToUpper().Normalize(),
                    ConcurrencyStamp = roleId
                });
        }
        

        var adminId = Guid.NewGuid().ToString();
        var admin = new User
        {
            Id = adminId,
            Email = "hristopanev20@gmail.com", // Has to be changed when official email is created
            NormalizedEmail = "HRISTOPANEV20@GMAIL.COM",
            EmailConfirmed = true,
            UserName = "admin",
            NormalizedUserName = "ADMIN"
        };

        PasswordHasher<User> passwordHasher = new();
        admin.PasswordHash = passwordHasher.HashPassword(admin, "Admin_1234");

        builder.Entity<User>()
            .HasData(admin);

        builder.Entity<IdentityUserRole<string>>()
            .HasData(new IdentityUserRole<string>()
            {
                RoleId = roleId,
                UserId = adminId
            });
        
        base.OnModelCreating(builder);
    }
    
    
}