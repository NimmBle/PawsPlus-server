using MediatR;
using PawsPlus.Application.Common;

namespace PawsPlus.Application.Identity.Commands.ResetPassword;

public class ResetPasswordCommand : IRequest<Result>
{
    public string UserId { get; set; }
    
    public string Token { get; set; }
    
    public string NewPassword { get; set; }
    
    public class ResetPasswordCommandHandler(IIdentity identity)
        : IRequestHandler<ResetPasswordCommand, Result>
    {
        public async Task<Result> Handle(ResetPasswordCommand request,
            CancellationToken cancellationToken)
        {
            var result = await identity.ResetPassword(request.UserId, request.Token, request.NewPassword);

            if (!result.Succeeded)
            {
                return false;
            }

            return true;
        }
    }
}