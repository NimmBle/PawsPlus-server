using PawsPlus.Application.Common;
using PawsPlus.Application.Identity.Commands.LoginUser;

namespace PawsPlus.Application.Identity;

public interface IIdentity
{
    Task<Result<IUser>> Register(string email, string firstName, string lastName, string password, string role);

    Task<Result<LoginOutputModel>> Login(LoginUserCommand userInput);
    
    Task<Result> ConfirmEmail(string userId, string token);
    
    Task<Result> ChangePassword(string email, string currentPassword, string newPassword);
    
    Task<IList<string>> GetRoles(string userId);
    
    Task<string> GetEmail(string userId);
    
    Task<Result> ChangeEmail(string userId, string newEmail);
    
    Task<Result> SendPasswordResetEmail(string email);
    
    Task<Result> ResetPassword(string userId, string token, string newPassword);
}