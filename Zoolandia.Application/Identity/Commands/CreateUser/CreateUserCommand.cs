using MediatR;
using Zoolandia.Application.Common;

namespace Zoolandia.Application.Identity.Commands.CreateUser;

public class CreateUserCommand : UserInputModel, IRequest<Result>
{
    public string FirstName { get; set; } = default!;

    public string LastName { get; set; } = default!;
    
    public class CreateUserCommandHandler(IIdentity identity) : IRequestHandler<CreateUserCommand, Result>
    {
        public async Task<Result> Handle(
            CreateUserCommand request,
            CancellationToken cancellationToken)
        {
            var result = await identity.Register(request);

            if (!result.Succeeded)
                return Result.Failure(result.Errors); // remove Result.Failure after implementing IUser

            return result;
        }
    }
}