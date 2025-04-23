using MediatR;
using PawsPlus.Application.Common;

namespace PawsPlus.Application.Identity.Commands.ConfirmEmail;

public class ConfirmEmailCommand : IRequest<Result>
{
    public string UserId { get; set; } = default!;

    public string Token { get; set; } = default!;
    
    public class ConfirmEmailCommandHandler(IIdentity identity) 
        : IRequestHandler<ConfirmEmailCommand, Result>
    {
        public async Task<Result> Handle(ConfirmEmailCommand request,
            CancellationToken cancellationToken)
            => await identity.ConfirmEmail(request.UserId,
                request.Token);
    }
}