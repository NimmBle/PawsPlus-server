using Microsoft.AspNetCore.Identity;

namespace Zoolandia.Infrastructure.Identity;

public class RoleService : IRoleService
{
    private readonly RoleManager<IdentityRole> _roleManager;

    public RoleService(RoleManager<IdentityRole> roleManager)
    {
        _roleManager = roleManager;
    }

    public async Task EnsureRolesCreatedAsync()
    {
        string[] allRoles = { "Administrator", "Owner", "Sitter" };
        foreach (var role in allRoles)
        {
            if (!await _roleManager.RoleExistsAsync(role))
                await _roleManager.CreateAsync(new IdentityRole(role));
        }
    }
}