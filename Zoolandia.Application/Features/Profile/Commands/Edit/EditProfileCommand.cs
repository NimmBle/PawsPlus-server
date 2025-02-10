using MediatR;
using Zoolandia.Application.Common;
using Zoolandia.Application.Common.Contracts;
using Zoolandia.Domain.Repositories;

namespace Zoolandia.Application.Features.Profile.Commands.Edit;

public class EditProfileCommand 
    : EntityCommand<string>,
        IRequest<Result>
{
    
    public string FirstName { get; set; }
    
    public string LastName { get; set; }
    
    public string PhoneNumber { get; set; }
    
    public string PhotoUrl { get; set; }
    
    public string? Description { get; set; }
    
    public LocationInputModel Location { get; set; }
    
    
    public class EditUserCommandHandler(
        ICurrentUser currentUser,
        IProfileDomainRepository profileDomainRepository)
        : IRequestHandler<EditProfileCommand, Result>
    {
        public async Task<Result> Handle(
            EditProfileCommand request,
            CancellationToken cancellationToken)
        {
            var currentUserId = currentUser.UserId;
            var profile = await profileDomainRepository.FindByUser(currentUserId);

            if (profile == null)
                return false;
            
            if (request.Id != profile.Id)
                return "You cannot edit this User";

            profile
                .UpdateFirstName(request.FirstName)
                .UpdateLastName(request.LastName)
                .UpdatePhotoUrl(request.PhotoUrl)
                .UpdatePhoneNumber(request.PhoneNumber)
                .UpdateDescription(request.Description)
                .UpdateLocation(request.Location.PlaceId, 
                    request.Location.Latitude,
                    request.Location.Longitude);
            
            await profileDomainRepository.Update(profile);

            return true;
        }
    }
}