namespace Zoolandia.Infrastructure.Identity;

public interface IRoleService
{
    Task EnsureRolesCreatedAsync();
}