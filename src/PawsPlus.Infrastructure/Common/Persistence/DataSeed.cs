using Microsoft.AspNetCore.Identity;
using PawsPlus.Domain.Models;
using PawsPlus.Infrastructure.Identity;

namespace PawsPlus.Infrastructure.Common.Persistence;

public class DataSeed(PawsPlusDbContext context) : IInitializer
{

    public void Initialize()
    {
        // Seed Owner
        var ownerEmail = "owner@pawsplus.eu";
        if (!context.Users.Any(u => u.Email == ownerEmail))
        {
            var ownerProfile = new Profile("owner", "owner", "0878787878");
            context.Profiles.Add(ownerProfile);
            context.SaveChanges();

            var ownerId = Guid.NewGuid().ToString();
            var owner = new User
            {
                Id = ownerId,
                Email = ownerEmail,
                NormalizedEmail = ownerEmail.ToUpper().Normalize(),
                EmailConfirmed = true,
                UserName = "owner",
                NormalizedUserName = "OWNER",
                ProfileId = ownerProfile.Id
            };

            var ownerHasher = new PasswordHasher<User>();
            owner.PasswordHash = ownerHasher.HashPassword(owner, "Owner_123");
            context.Users.Add(owner);

            var ownerRole = context.Roles.FirstOrDefault(r => r.Name == "Owner");
            if (ownerRole != null)
            {
                context.UserRoles.Add(new IdentityUserRole<string>
                {
                    UserId = ownerId,
                    RoleId = ownerRole.Id
                });
            }
            context.SaveChanges();
        }

        // Seed Sitter
        var sitterEmail = "sitter@pawsplus.eu";
        if (!context.Users.Any(u => u.Email == sitterEmail))
        {
            var sitterProfile = new Profile("sitter", "sitter", "0878787878");
            context.Profiles.Add(sitterProfile);
            context.SaveChanges();

            var sitterId = Guid.NewGuid().ToString();
            var sitter = new User
            {
                Id = sitterId,
                Email = sitterEmail,
                NormalizedEmail = sitterEmail.ToUpper().Normalize(),
                EmailConfirmed = true,
                UserName = "sitter",
                NormalizedUserName = "SITTER",
                ProfileId = sitterProfile.Id
            };

            var sitterHasher = new PasswordHasher<User>();
            sitter.PasswordHash = sitterHasher.HashPassword(sitter, "Sitter_123");
            context.Users.Add(sitter);

            var sitterRole = context.Roles.FirstOrDefault(r => r.Name == "Sitter");
            if (sitterRole != null)
            {
                context.UserRoles.Add(new IdentityUserRole<string>
                {
                    UserId = sitterId,
                    RoleId = sitterRole.Id
                });
            }
            context.SaveChanges();
        }

        // Seed Admin
        var adminEmail = "admin@pawsplus.eu";
        if (!context.Users.Any(u => u.Email == adminEmail))
        {
            var adminProfile = new Profile("admin", "admin", "0878787878");
            context.Profiles.Add(adminProfile);
            context.SaveChanges();

            var adminId = Guid.NewGuid().ToString();
            var admin = new User
            {
                Id = adminId,
                Email = adminEmail,
                NormalizedEmail = adminEmail.ToUpper().Normalize(),
                EmailConfirmed = true,
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                ProfileId = adminProfile.Id
            };

            var adminHasher = new PasswordHasher<User>();
            admin.PasswordHash = adminHasher.HashPassword(admin, "Admin_123");
            context.Users.Add(admin);

            var adminRole = context.Roles.FirstOrDefault(r => r.Name == "Administrator");
            if (adminRole != null)
            {
                context.UserRoles.Add(new IdentityUserRole<string>
                {
                    UserId = adminId,
                    RoleId = adminRole.Id
                });
            }
            context.SaveChanges();
        }
    }
}