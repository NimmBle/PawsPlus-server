using Zoolandia.Application.Common;
using Zoolandia.Application.Features.Profile.Queries;
using Zoolandia.Application.Features.Profile.Queries.Mine;
using Zoolandia.Application.Identity.Commands;
using Zoolandia.Application.Identity.Commands.CreateUser;
using Zoolandia.Application.Identity.Commands.LoginUser;

namespace Zoolandia.Application.Identity;

public interface IIdentity
{
    // Task<Result<MineProfileOutputModel>> GetUserProfile(string userId);
    
    Task<Result<IUser>> Register(CreateUserCommand userInput);

    Task<Result<LoginOutputModel>> Login(LoginUserCommand userInput);

    Task<Result> ChangeEmail(string userId, string newEmail);

    Task<bool> EmailAlreadyExists(string email);

    Task<Result> ConfirmEmail(string id, string token);
    
    Task<IList<string>> GetRoles(string userId);
}