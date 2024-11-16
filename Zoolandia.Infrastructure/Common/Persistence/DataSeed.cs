using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Zoolandia.Infrastructure.Identity;

namespace Zoolandia.Infrastructure.Common.Persistence;

public static class DataSeed
{
    public static async Task SeedData(IServiceProvider serviceProvider)
    {
        using (var context = serviceProvider.GetRequiredService<ZoolandiaDbContext>())
        {
            // Seed roles if they don't exist
            if (!context.Roles.Any())
            {
                string[] roleNames = { "Owner", "Sitter", "Administrator" };
                string roleId = default!;
                foreach (var role in roleNames)
                {
                
                    roleId = Guid.NewGuid().ToString();
                    await context.Roles.AddAsync(new IdentityRole
                        {
                            Id = roleId,
                            Name = role,
                            NormalizedName = role.ToUpper().Normalize(),
                            ConcurrencyStamp = roleId
                        });
                }
                
                
                var adminId = Guid.NewGuid().ToString();
                var adminEmail = "hristopanev20@gmail.com"; // Has to be changed when official email is created
                var admin = new User
                {
                    Id = adminId,
                    Email = adminEmail,
                    NormalizedEmail = adminEmail.ToUpper().Normalize(),
                    EmailConfirmed = true,
                    UserName = "admin",
                    NormalizedUserName = "ADMIN"
                };
                
                PasswordHasher<User> passwordHasher = new();
                admin.PasswordHash = passwordHasher.HashPassword(admin, "Admin_1234");

                await context.Users.AddAsync(admin);

                context.UserRoles.AddAsync(new IdentityUserRole<string>()
                {
                    RoleId = roleId,
                    UserId = adminId
                });
                    
                await context.SaveChangesAsync();
            }
        }
    }
}