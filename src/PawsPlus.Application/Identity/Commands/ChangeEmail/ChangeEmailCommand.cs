using MediatR;
using PawsPlus.Application.Common;

namespace PawsPlus.Application.Identity.Commands.ChangeEmail;

public class ChangeEmailCommand : IRequest<Result>
{
    public string Id { get; set; }
    
    public string NewEmail { get; set; }
    
    public class ChangeEmailCommandHandler(IIdentity identity) : IRequestHandler<ChangeEmailCommand, Result>
    {
        public Task<Result> Handle(ChangeEmailCommand request, CancellationToken cancellationToken)
            => identity.ChangeEmail(request.Id, request.NewEmail);
    }
}