using Zoolandia.Applicaiton.Identity.Commands;
using Zoolandia.Application.Common;

namespace Zoolandia.Applicaiton.Identity;

public interface IIdentity
{
    Task<Result> Register(CreateUserCommand userInput);
}