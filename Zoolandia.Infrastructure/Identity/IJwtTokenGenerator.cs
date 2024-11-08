namespace Zoolandia.Infrastructure.Identity;

public interface IJwtTokenGenerator
{
    string GenerateToken(string userId, string userName);
}