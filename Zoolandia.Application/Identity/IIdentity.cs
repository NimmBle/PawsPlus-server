using Zoolandia.Applicaiton.Identity.Commands.CreateUser;
using Zoolandia.Applicaiton.Identity.Commands.LoginUser;
using Zoolandia.Application.Common;

namespace Zoolandia.Applicaiton.Identity;

public interface IIdentity
{
    Task<Result> Register(CreateUserCommand userInput);

    Task<Result<LoginSuccessModel>> Login(LoginUserCommand userInput);
}