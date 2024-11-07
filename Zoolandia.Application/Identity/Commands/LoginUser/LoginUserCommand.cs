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

            // change (add validation)
            return result;
        }
    }
}