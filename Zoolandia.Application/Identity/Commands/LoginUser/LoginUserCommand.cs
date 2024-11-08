using MediatR;
using Zoolandia.Application.Common;

namespace Zoolandia.Application.Identity.Commands.LoginUser;

public class LoginUserCommand : UserInputModel, IRequest<Result<LoginOutputModel>>
{
    public class LoginUserCommandHandler(IIdentity identity) 
        : IRequestHandler<LoginUserCommand, 
            Result<LoginOutputModel>>
    {
        public async Task<Result<LoginOutputModel>> Handle(
            LoginUserCommand request,
            CancellationToken cancellationToken)
        {
            var result = await identity.Login(request);

            if (!result.Succeeded)
                return result.Errors;

            var user = result.Data;

            return new LoginOutputModel(user.Id, user.Token);
        }
    }
}