using MediatR;
using Zoolandia.Application.Common;

namespace Zoolandia.Application.Features.Profile.Commands;

public class EditProfileCommand : EntityCommand<string>, IRequest<Result>
{
    
    public string FirstName { get; set; }
    
    public string LastName { get; set; }
    
    public string PhoneNumber { get; set; }
    
    public string PhotoUrl { get; set; }
    
    public string Description { get; set; }
    
    
    public class EditUserCommandHandler : IRequestHandler<EditProfileCommand, Result>
    {
        public Task<Result> Handle(
            EditProfileCommand request,
            CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}