using MediatR;
using Zoolandia.Application.Common;

namespace Zoolandia.Applicaiton.Identity.Commands.LoginUser;

public class LoginUserCommand : UserInputModel, IRequest<Result>
{
    public class LoginUserCommandHandler(IIdentity identity) : IRequestHandler<LoginUserCommand, Result>
    {
        public async Task<Result> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var result = await identity.Login(request);

            if (!result.Succeeded)
                return Result.Failure(result.Errors);
            ;
            return result;
        }
    }
}