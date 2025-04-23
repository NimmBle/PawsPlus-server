namespace PawsPlus.Infrastructure.Identity;

public interface IJwtTokenGenerator
{
    string GenerateToken(string userId, string userName, IList<string> roles);
}