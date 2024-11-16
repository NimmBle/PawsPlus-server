using Zoolandia.Application.Common;
using Zoolandia.Application.Identity.Commands.CreateUser;
using Zoolandia.Application.Identity.Commands.LoginUser;

namespace Zoolandia.Application.Identity;

public interface IIdentity
{
    Task<Result<IUser>> Register(CreateUserCommand userInput);

    Task<Result<LoginSuccessModel>> Login(LoginUserCommand userInput);
    

}