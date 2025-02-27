using MediatR;
using PawsPlus.Application.Common;

namespace PawsPlus.Application.Identity.Commands.ChangePassword;

public class ChangePasswordCommand : IRequest<Result>
{
    public string Email { get; init; }
    
    public string currentPassword { get; init; }
    
    public string newPassword { get; init; }
    
    public class ChangePasswordCommandHandler(IIdentity identity) : IRequestHandler<ChangePasswordCommand, Result>
    {
        public async Task<Result> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
            => await identity.ChangePassword(request.Email, request.currentPassword, request.newPassword);
    }
}