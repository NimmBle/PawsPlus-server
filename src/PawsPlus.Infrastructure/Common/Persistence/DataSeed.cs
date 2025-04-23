using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PawsPlus.Domain.Models;
using PawsPlus.Infrastructure.Identity;

namespace PawsPlus.Infrastructure.Common.Persistence;

public static class DataSeed
{
    public static async Task SeedData(IServiceProvider serviceProvider)
    {
        using (var context = serviceProvider.GetRequiredService<PawsPlusDbContext>())
        {
            // Seed roles if they don't exist
            var roleNames = new[] { "Owner", "Sitter", "Administrator" };
            foreach (var roleName in roleNames)
            {
                var roleExists = await context.Roles.AnyAsync(r => r.Name == roleName);
                if (!roleExists)
                {
                    var roleId = Guid.NewGuid().ToString();
                    await context.Roles.AddAsync(new IdentityRole
                    {
                        Id = roleId,
                        Name = roleName,
                        NormalizedName = roleName.ToUpper().Normalize(),
                        ConcurrencyStamp = roleId
                    });
                }
            }
            await context.SaveChangesAsync();

            // Seed Owner
            var ownerEmail = "owner@pawsplus.eu";
            if (!await context.Users.AnyAsync(u => u.Email == ownerEmail))
            {
                var ownerProfile = new Profile("owner", "owner", "0878787878");
                context.Profiles.Add(ownerProfile);
                await context.SaveChangesAsync();

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

                var ownerRole = await context.Roles.FirstOrDefaultAsync(r => r.Name == "Owner");
                if (ownerRole != null)
                {
                    context.UserRoles.Add(new IdentityUserRole<string>
                    {
                        UserId = ownerId,
                        RoleId = ownerRole.Id
                    });
                }
                await context.SaveChangesAsync();
            }

            // Seed Sitter
            var sitterEmail = "sitter@pawsplus.eu";
            if (!await context.Users.AnyAsync(u => u.Email == sitterEmail))
            {
                var sitterProfile = new Profile("sitter", "sitter", "0878787878");
                context.Profiles.Add(sitterProfile);
                await context.SaveChangesAsync();

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

                var sitterRole = await context.Roles.FirstOrDefaultAsync(r => r.Name == "Sitter");
                if (sitterRole != null)
                {
                    context.UserRoles.Add(new IdentityUserRole<string>
                    {
                        UserId = sitterId,
                        RoleId = sitterRole.Id
                    });
                }
                await context.SaveChangesAsync();
            }

            // Seed Admin
            var adminEmail = "admin@pawsplus.eu";
            if (!await context.Users.AnyAsync(u => u.Email == adminEmail))
            {
                var adminProfile = new Profile("admin", "admin", "0878787878");
                context.Profiles.Add(adminProfile);
                await context.SaveChangesAsync();

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

                var adminRole = await context.Roles.FirstOrDefaultAsync(r => r.Name == "Administrator");
                if (adminRole != null)
                {
                    context.UserRoles.Add(new IdentityUserRole<string>
                    {
                        UserId = adminId,
                        RoleId = adminRole.Id
                    });
                }
                await context.SaveChangesAsync();
            }
        }
    }
}