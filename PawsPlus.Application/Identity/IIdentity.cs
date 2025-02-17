using PawsPlus.Application.Common;
using PawsPlus.Application.Identity.Commands.LoginUser;

namespace PawsPlus.Application.Identity;

public interface IIdentity
{
    // Task<Result<MineProfileOutputModel>> GetUserProfile(string userId);

    Task<Result<IUser>> Register(string email, string firstName, string lastName, string password, string role);

    Task<Result<LoginOutputModel>> Login(LoginUserCommand userInput);

    Task<Result> ChangeEmail(string userId, string newEmail);
    
    Task<Result> ConfirmEmail(string userid, string token);
    
    // Task<bool> EmailAlreadyExists(string email);
    
    // Task SendPasswordResetEmail(string email);
    
    // Task<Result> ResetPassword(string email, string oldPassword, string newPassword);
    
    Task<IList<string>> GetRoles(string userId);
}