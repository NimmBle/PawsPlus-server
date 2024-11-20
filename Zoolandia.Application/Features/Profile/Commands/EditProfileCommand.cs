using MediatR;
using Zoolandia.Application.Common;
using Zoolandia.Domain.Repositories;

namespace Zoolandia.Application.Features.Profile.Commands;

public class EditProfileCommand 
    : EntityCommand<string>,
        IRequest<Result>
{
    
    public string FirstName { get; set; }
    
    public string LastName { get; set; }
    
    public string PhoneNumber { get; set; }
    
    public string PhotoUrl { get; set; }
    
    public string Description { get; set; }
    
    
    public class EditUserCommandHandler(IProfileDomainRepository profileRepository)
        : IRequestHandler<EditProfileCommand, Result>
    {
        public async Task<Result> Handle(
            EditProfileCommand request,
            CancellationToken cancellationToken)
        {
            var profile = await profileRepository.FindById(request.Id);

            if (profile == null)
                return false;

            profile
                .UpdateFirstName(request.FirstName)
                .UpdateLastName(request.LastName)
                .UpdatePhotoUrl(request.PhotoUrl)
                .UpdatePhoneNumber(request.PhoneNumber)
                .UpdateDescription(request.Description);
            
            
            await profileRepository.Update(profile);

            return true;
        }
    }
}