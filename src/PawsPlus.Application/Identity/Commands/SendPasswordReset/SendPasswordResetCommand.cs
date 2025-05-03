using MediatR;
using PawsPlus.Application.Common;
using PawsPlus.Application.Common.Contracts;

namespace PawsPlus.Application.Identity.Commands.SendPasswordReset;

public class SendPasswordResetCommand : IRequest<Result>
{
    
    public class SendPasswordResetCommandHandler(ICurrentUser currentUser,
        IIdentity identity) : IRequestHandler<SendPasswordResetCommand, Result>
    {
        public async Task<Result> Handle(SendPasswordResetCommand request, CancellationToken cancellationToken)
        {
            var userId = currentUser.UserId;
            var result = await identity.SendPasswordResetEmail(userId);

            return result;
        }
    }
}